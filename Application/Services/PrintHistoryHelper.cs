using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// PrintHistoryHelper
    /// </summary>
    public class PrintHistoryHelper
    {
        #region Instance Members

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        private readonly ILog Log;

        #endregion

        #region Properties

        private JsonSerializer Serializer
        {
            get
            {
                return new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };
            }
        }

        #endregion

        #region Ctor

        public PrintHistoryHelper()
        {
            Log = InstanceFactory.GetInstance<ILog>();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Create a PrintHistory entry in the database
        /// </summary>
        /// <param name="userId">The user instigating the activity</param>
        /// <param name="type">The type of print out being actioned</param>
        /// <param name="turnaroundId">The turnaroundId the history is being created for</param>
        /// <param name="turnaroundEventId">The turnaround event id of the activity which requires a print out, if available.</param>
        /// <param name="batchId">The batch id of the activity which requires a print out, if available</param>
        /// <param name="notificationRuleId">The notification rule id for the notification rule that has requested the print</param>
        /// <returns></returns>
        /// <summary>
        /// CreatePrintHistory operation
        /// </summary>
        public PrintHistoryModel CreatePrintHistory(int userId, PrintContentTypeIdentifier type, int? turnaroundId, int? turnaroundEventId, int? batchId, int? notificationRuleId)
        {
            var turnaroundIds = new List<int>();
            var turnaroundEventIds = new List<int>();
            if (turnaroundId.HasValue)
            {
                turnaroundIds.Add(turnaroundId.Value);
            }
            if (turnaroundEventId.HasValue)
            {
                turnaroundEventIds.Add(turnaroundEventId.Value);
            }

            return CreatePrintHistory(userId, type, turnaroundIds, turnaroundEventIds, new List<int>(), batchId, notificationRuleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The user instigating the activity</param>
        /// <param name="type">The type of print out being actioned</param>
        /// <param name="turnaroundIds">List of turnaroundids the history is to be created for</param>
        /// <param name="turnaroundEventIds">List of turnaround event ids that require a printout</param>
        /// <param name="deliveryNoteIds">List of delivery note ids</param>
        /// <param name="batchId">The batch id of the activity which requires a print out, if available</param>
        /// <param name="notificationRuleId">The notification rule id for the notification rule that has requested the print</param>
        /// <returns></returns>
        /// <summary>
        /// CreatePrintHistory operation
        /// </summary>
        public PrintHistoryModel CreatePrintHistory(int userId, PrintContentTypeIdentifier type, List<int> turnaroundIds, List<int> turnaroundEventIds, List<int> deliveryNoteIds, int? batchId, int? notificationRuleId)
        {
            var model = new PrintHistoryModel();
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var printHistory = PrintHistoryFactory.CreateEntity(workUnit,
                    printedByUserId: userId,
                    created: DateTime.UtcNow,
                    printContentTypeId: (int)type,
                    contentRemoved: false
                );

                var printHistoryRepo = PrintHistoryRepository.New(workUnit);

                printHistoryRepo.Add(printHistory);

                if (turnaroundIds != null)
                {
                    turnaroundIds.ForEach(x => printHistory.PrintHistoryTurnaround.Add(PrintHistoryTurnaroundFactory.CreateEntity(workUnit,
                        printHistoryId: printHistory.PrintHistoryId,
                        turnaroundId: x
                    )));
                }

                if (turnaroundEventIds != null)
                {
                    turnaroundEventIds.ForEach(x => printHistory.PrintHistoryTurnaroundEvent.Add(PrintHistoryTurnaroundEventFactory.CreateEntity(workUnit,
                        printHistoryId: printHistory.PrintHistoryId,
                        turnaroundEventId: x
                    )));
                }

                if (deliveryNoteIds != null)
                {
                    deliveryNoteIds.ForEach(x => printHistory.PrintHistoryDeliveryNote.Add(PrintHistoryDeliveryNoteFactory.CreateEntity(workUnit,
                        printHistoryId: printHistory.PrintHistoryId,
                        deliveryNoteId: x
                    )));
                }

                if (batchId != null)
                {
                    printHistory.PrintHistoryBatch.Add(PrintHistoryBatchFactory.CreateEntity(workUnit,
                        printHistoryId: printHistory.PrintHistoryId,
                        batchId: batchId.Value
                    ));
                }

                if (notificationRuleId != null)
                {
                    printHistory.PrintHistoryNotificationRule.Add(PrintHistoryNotificationRuleFactory.CreateEntity(workUnit,
                        printHistoryId: printHistory.PrintHistoryId,
                        notificationRuleId: notificationRuleId.Value
                    ));
                }

                model = ConvertHistoryEntityToModel(printHistory);

                printHistoryRepo.Save();
                model.Id = printHistory.PrintHistoryId;
            }
            return model;
        }

        /// <summary>
        /// Creates a print history content entry in the database and creates the file to store the json content.
        /// </summary>
        /// <typeparam name="T">The class type of the content e.g PDFContent or LabelContent.</typeparam>
        /// <param name="printHistoryId">The Id of the print history entry in the db this content is attached to.</param>
        /// <param name="printerType">The type of printer used for the print out.</param>
        /// <param name="content">The actual content class to be serialized to disk.</param>
        /// <returns></returns>
        public PrintHistoryContentModel CreatePrintHistoryContent<T>(int printHistoryId,PrintHistoryPrinterType printerType, T content) where T : class
        {
            {
                var historyContent = PrintHistoryContentFactory.CreateEntity(workUnit,
                    printHistoryId: printHistoryId,
                    printerTypeId: (byte)printerType,
                    contentId: Guid.NewGuid(),
                    ordinal: DateTime.UtcNow
                );

                var printHistoryContentRepo = PrintHistoryContentRepository.New(workUnit);
                printHistoryContentRepo.Add(historyContent);
                printHistoryContentRepo.Save();
                var result = ConvertHistoryContentEntityToModel(historyContent);
                result.ContentJson = SerializePrintData(content);
                SerializePrintDataToDisk<T>(result.PrintHistoryId, result.ContentId, content);

                return result;
            }
        }

        /// <summary>
        /// Gets json data from the print history doc store.
        /// </summary>
        /// <param name="printHistoryId">The Id of the print history entry in the db.</param>
        /// <param name="contentId">The guid that identifies the content to be retrieved.</param>
        /// <returns>a json string containing the content.</returns>
        /// <summary>
        /// GetPrintHistoryJsonDataFromDisk operation
        /// </summary>
        public string GetPrintHistoryJsonDataFromDisk(int printHistoryId, Guid contentId)
        {
            try
            {
                using (StreamReader file = File.OpenText($"{SystemSettings.PrintHistoryFileStore}\\{printHistoryId.ToString()}\\{contentId.ToString()}"))
                {
                    return file.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of fully populated print history models with content, optionally including json data from the file system.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id to use to lookup the print history.</param>
        /// <param name="includeData">Indicate whether to fetch the json data from the file system.</param>
        /// <returns>A list of Print History model objects.</returns>
        /// <summary>
        /// GetPrintHistory operation
        /// </summary>
        public List<PrintHistoryModel> GetPrintHistory(int turnaroundId, bool includeData)
        {
            
            List<PrintHistoryModel> printHistory = new List<PrintHistoryModel>();

            try
            {
                {
                    var printHistoryRepo = PrintHistoryRepository.New(workUnit);

                    foreach (var history in printHistoryRepo.GetByTurnaroundId(turnaroundId))
                    {
                        printHistory.Add(new PrintHistoryModel
                        {
                            Id = history.PrintHistoryId,
                            Content = GetPrintHistoryContent(history.PrintHistoryId, includeData),
                            ContentRemoved = history.ContentRemoved,
                            ContentType = (PrintContentTypeIdentifier)history.PrintContentTypeId,
                            Created = history.Created,
                            UserId = history.PrintedByUserId,
                            Batches = history.PrintHistoryBatch.Select(item => new PrintHistoryBatchModel
                            {
                                Id = item.PrintHistoryBatchId,
                                PrintHistoryId = item.PrintHistoryId,
                                BatchId = item.BatchId
                            }).ToList(),
                            Turnarounds = history.PrintHistoryTurnaround.Select(item => new PrintHistoryTurnaroundModel
                            {
                                Id = item.PrintHistoryTurnaroundId,
                                PrintHistoryId = item.PrintHistoryId,
                                TurnaroundId = item.TurnaroundId
                            }).ToList(),
                            TurnaroundEvents = history.PrintHistoryTurnaroundEvent.Select(item => new PrintHistoryTurnaroundEventModel
                            {
                                Id = item.PrintHistoryTurnaroundEventId,
                                PrintHistoryId = item.PrintHistoryId,
                                TurnaroundEventId = item.TurnaroundEventId
                            }).ToList(),
                            NotificationRules = history.PrintHistoryNotificationRule.Select(item => new PrintHistoryNotificationRuleModel
                            {
                                Id = item.PrintHistoryNotificationRuleId,
                                PrintHistoryId = item.PrintHistoryId,
                                NotificationRuleId = item.NotificationRuleId
                            }).ToList()

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex, "Print History Helper Get History Failed");
            }

            return printHistory;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts an EF Print History entity to a model.
        /// </summary>
        /// <param name="entity">The EF entity to convert.</param>
        /// <returns>The populated model.</returns>
        private PrintHistoryModel ConvertHistoryEntityToModel(PrintHistory entity)
        {
            return new PrintHistoryModel
            {
                Id = entity.PrintHistoryId,
                UserId = entity.PrintedByUserId,
                Created = entity.Created,
                ContentType = (PrintContentTypeIdentifier)entity.PrintContentTypeId,
                ContentRemoved = entity.ContentRemoved,
                Content = ConvertHistoryContentEntityToModel(entity.PrintHistoryContent.ToList()),
                Batches = ConvertHistoryBatchEntityToModel(entity.PrintHistoryBatch.ToList()),
                DeliveryNotes = ConvertHistoryDeliveryNoteEntityToModel(entity.PrintHistoryDeliveryNote.ToList()),
                Turnarounds = ConvertHistoryTurnaroundEntityToModel(entity.PrintHistoryTurnaround.ToList()),
                TurnaroundEvents = ConvertHistoryTurnaroundEventEntityToModel(entity.PrintHistoryTurnaroundEvent.ToList()),
                NotificationRules = ConvertHistoryNotificationRuleEntityToModel(entity.PrintHistoryNotificationRule.ToList())
            };
        }

        /// <summary>
        /// Converts a list of Print History Content EF entities to a list of Print History Content Models.
        /// The json data is not populated as it is not part of the entity set.
        /// </summary>
        /// <param name="entity">The list of EF entities to convert</param>
        /// <returns>A list of populated model objects.</returns>
        private List<PrintHistoryContentModel> ConvertHistoryContentEntityToModel(List<PrintHistoryContent> entity)
        {
            return entity.Select(item => new PrintHistoryContentModel
            {
                Id = item.PrintHistoryContentId,
                PrintHistoryId = item.PrintHistoryId,
                ContentId = item.ContentId,
                PrinterType = (PrintHistoryPrinterType)item.PrinterTypeId,
                Ordinal = item.Ordinal
            }).ToList();
        }
        /// <summary>
        /// Converts a list of Print History Delivery Note EF entities to a list of Print History Delivery Note Models.
        /// The json data is not populated as it is not part of the entity set.
        /// </summary>
        /// <param name="entity">The list of EF entities to convert</param>
        /// <returns>A list of populated model objects.</returns>
        private List<PrintHistoryDeliveryNoteModel> ConvertHistoryDeliveryNoteEntityToModel(List<PrintHistoryDeliveryNote> entity)
        {
            return entity.Select(item => new PrintHistoryDeliveryNoteModel
            {
                Id = item.PrintHistoryDeliveryNoteId,
                PrintHistoryId = item.PrintHistoryId,
                DeliveryNoteId = item.DeliveryNoteId
            }).ToList();
        }
        /// <summary>
        /// Converts a list of Print History Turnaround EF entities to a list of Print History Turnaround Models.
        /// The json data is not populated as it is not part of the entity set.
        /// </summary>
        /// <param name="entity">The list of EF entities to convert</param>
        /// <returns>A list of populated model objects.</returns>
        private List<PrintHistoryTurnaroundModel> ConvertHistoryTurnaroundEntityToModel(List<PrintHistoryTurnaround> entity)
        {
            return entity.Select(item => new PrintHistoryTurnaroundModel
            {
                Id = item.PrintHistoryTurnaroundId,
                PrintHistoryId = item.PrintHistoryId,
                TurnaroundId = item.TurnaroundId
            }).ToList();
        }
        /// <summary>
        /// Converts a list of Print History Turnaround Event EF entities to a list of Print History Turnaround Event Models.
        /// The json data is not populated as it is not part of the entity set.
        /// </summary>
        /// <param name="entity">The list of EF entities to convert</param>
        /// <returns>A list of populated model objects</returns>
        private List<PrintHistoryTurnaroundEventModel> ConvertHistoryTurnaroundEventEntityToModel(List<PrintHistoryTurnaroundEvent> entity)
        {
            return entity.Select(item => new PrintHistoryTurnaroundEventModel
            {
                Id = item.PrintHistoryTurnaroundEventId,
                PrintHistoryId = item.PrintHistoryId,
                TurnaroundEventId = item.TurnaroundEventId
            }).ToList();
        }
        /// <summary>
        /// Converts a list of Print History Batch EF entities to a list of Print History Batch Models.
        /// The json data is not populated as it is not part of the entity set.
        /// </summary>
        /// <param name="entity">The list of EF entities to convert</param>
        /// <returns>A list of populated model objects</returns>
        private List<PrintHistoryBatchModel> ConvertHistoryBatchEntityToModel(List<PrintHistoryBatch> entity)
        {
            return entity.Select(item => new PrintHistoryBatchModel
            {
                Id = item.PrintHistoryBatchId,
                PrintHistoryId = item.PrintHistoryId,
                BatchId = item.BatchId
            }).ToList();
        }
        /// <summary>
        /// Converts a list of Print History Notification Rule EF entities to a list of Print History Notification Rule Models.
        /// The json data is not populated as it is not part of the entity set.
        /// </summary>
        /// <param name="entity">The list of EF entities to convert</param>
        /// <returns>A list of populated model objects</returns>
        private List<PrintHistoryNotificationRuleModel> ConvertHistoryNotificationRuleEntityToModel(List<PrintHistoryNotificationRule> entity)
        {
            return entity.Select(item => new PrintHistoryNotificationRuleModel
            {
                Id = item.PrintHistoryNotificationRuleId,
                PrintHistoryId = item.PrintHistoryId,
                NotificationRuleId = item.NotificationRuleId
            }).ToList();
        }

        /// <summary>
        /// Converts a single Print History Content EF Entity to a Model.
        /// </summary>
        /// <param name="entity">The EF entity to convert.</param>
        /// <returns>A populated model.</returns>
        private PrintHistoryContentModel ConvertHistoryContentEntityToModel(PrintHistoryContent entity)
        {
            return new PrintHistoryContentModel
            {
                Id = entity.PrintHistoryContentId,
                PrintHistoryId = entity.PrintHistoryId,
                ContentId = entity.ContentId,
                PrinterType = (PrintHistoryPrinterType)entity.PrinterTypeId,
                Ordinal = entity.Ordinal,
            };
        }

        /// <summary>
        /// Gets all content for a specified print history entry. Optionally fetching the json data from the file system.
        /// </summary>
        /// <param name="printHistoryId">The Print History entry to retrieve data for.</param>
        /// <param name="includeData">Specify if fetching of json data from the file system is required.</param>
        /// <returns></returns>
        private List<PrintHistoryContentModel> GetPrintHistoryContent(int printHistoryId, bool includeData)
        {
            var historyContent = new List<PrintHistoryContentModel>();

            {
                var printHistoryContentRepo = PrintHistoryContentRepository.New(workUnit);

                foreach (var item in printHistoryContentRepo.GetByPrintHistoryId(printHistoryId).OrderBy(x => x.Ordinal).ToList())
                {
                    historyContent.Add(new PrintHistoryContentModel
                    {
                        Id = item.PrintHistoryContentId,
                        PrintHistoryId = item.PrintHistoryId,
                        ContentId = item.ContentId,
                        PrinterType = (PrintHistoryPrinterType)item.PrinterTypeId,
                        Ordinal = item.Ordinal,
                        ContentJson = includeData ? GetPrintHistoryJsonDataFromDisk(item.PrintHistoryId, item.ContentId) : null
                    });
                }
            }
            return historyContent;
        }
                 
        /// <summary>
        /// Seralize a print history content object and return the string data.
        /// </summary>
        /// <typeparam name="T">The object type being seralized e.g PDFContent or LabelContent.</typeparam>
        /// <param name="content">The populated content object.</param>
        /// <returns>A json string.</returns>
        private string SerializePrintData<T>(T content) where T : class
        {
            return JsonConvert.SerializeObject(content, _settings);
        }

        /// <summary>
        /// Seralize a print history content object directly to disk.
        /// </summary>
        /// <typeparam name="T">The object type being serialized eg. PDFContent or LabelContent.</typeparam>
        /// <param name="printHistoryId">The Id of the print history this content is attached to.</param>
        /// <param name="contentId">The GUID of the content used to create the file.</param>
        /// <param name="content">The populated content object.</param>
        /// <returns></returns>
        private bool SerializePrintDataToDisk<T>(int printHistoryId, Guid contentId, T content) where T : class
        {
            try
            {
                var directory = $"{SystemSettings.PrintHistoryFileStore}\\{printHistoryId.ToString()}";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (StreamWriter file = File.CreateText($"{SystemSettings.PrintHistoryFileStore}\\{printHistoryId.ToString()}\\{contentId.ToString()}"))
                {
                    Serializer.Serialize(file, content);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Convert content from Json string to object
        /// </summary>
        /// <typeparam name="T">The object type being converted from JSON eg. PDFContent or LabelContent.</typeparam>
        /// <param name="jsonContent">The JSON content that needs converting</param>
        /// <returns>A populated object using the data from the jsonContent</returns>
        public T ConvertContentFromJsonContent<T>(string jsonContent) where T : class
        {
            try
            {                
                if (jsonContent != null)
                {
                    return JsonConvert.DeserializeObject<T>(jsonContent, _settings);
                }
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        #endregion
    }
}