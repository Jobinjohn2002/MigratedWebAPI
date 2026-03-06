using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// MasterRepository
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// MasterRepository
    /// </summary>
    public class MasterRepository
    {
        private IOperativeRepository<Master> _repository { get; set; }
        public IOperativeRepository<Master> Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterRepository"/> class.
        /// </summary>
        /// <param name="containerMasterRepository">The container master repository.</param>
        /// <param name="itemMasterRepository">The item master repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <remarks></remarks>
        public MasterRepository(IOperativeRepository<ContainerMaster> containerMasterRepository,
                                IOperativeRepository<ItemMaster> itemMasterRepository, IUnitOfWork unitOfWork)
        {
            ContainerMasterRepository = containerMasterRepository;
            ItemMasterRepository = itemMasterRepository;
            ContainerMasterRepository.UnitOfWork = ItemMasterRepository.UnitOfWork = unitOfWork;
        }

        public MasterRepository(IOperativeRepository<Master> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            Repository.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterRepository"/> class.
        /// </summary>
        /// <param name="containerMasterRepository">The container master repository.</param>
        /// <param name="itemMasterRepository">The item master repository.</param>
        /// /// <param name="defectRepository">The defect repository.</param>
        /// /// <param name="customerRepository">The customer repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <remarks></remarks>
        public MasterRepository(IOperativeRepository<ContainerMaster> containerMasterRepository,
            IOperativeRepository<ItemMaster> itemMasterRepository,
            IOperativeRepository<Defect> defectRepository,
            IOperativeRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            ContainerMasterRepository = containerMasterRepository;
            ItemMasterRepository = itemMasterRepository;
            DefectRepository = defectRepository;
            CustomerRepository = customerRepository;
            ContainerMasterRepository.UnitOfWork = ItemMasterRepository.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets or sets the container master repository.
        /// </summary>
        /// <value>The container master repository.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterRepository
        /// </summary>
        public IOperativeRepository<ContainerMaster> ContainerMasterRepository { get; set; }
        /// <summary>
        /// Gets or sets the item master repository.
        /// </summary>
        /// <value>The item master repository.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemMasterRepository
        /// </summary>
        public IOperativeRepository<ItemMaster> ItemMasterRepository { get; set; }

        /// <summary>
        /// Gets or sets the Defect repository.
        /// </summary>
        /// <value>The Defect repository.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectRepository
        /// </summary>
        public IOperativeRepository<Defect> DefectRepository { get; set; }

        /// <summary>
        /// Gets or sets the Customer Defect repository.
        /// </summary>
        /// <value>The Customer Defect repository.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerRepository
        /// </summary>
        public IOperativeRepository<Customer> CustomerRepository { get; set; }

        /// <summary>
        /// GetById operation
        /// </summary>
        public Master GetById(int masterId)
        {
            var containerMaster = ContainerMasterRepository.All().SingleOrDefault(a => a.ContainerMasterId == masterId);

            if (containerMaster != null)
            {
                return Master.ParseContainerExp.Invoke(containerMaster);
            }
            else
            {
                var itemMaster = ItemMasterRepository.All().SingleOrDefault(i => i.ItemMasterId == masterId);

                if (itemMaster != null)
                {
                    return Master.ParseItemExp.Invoke(itemMaster);
                }
            }

            return null;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetRevisions operation
        /// </summary>
        public IQueryable<Master> GetRevisions(MasterType masterType, int masterid)
        {
            if (masterType == MasterType.ContainerMaster)
            {
                return ContainerMasterRepository.Find(i => i.ContainerMasterId == masterid).Select(c => c.ContainerMasterDefinition).SelectMany(i => i.ContainerMasters).AsExpandable().
                    Select(i => Master.ParseContainerExp.Invoke(i));
            }
            if (masterType == MasterType.ItemMaster)
            {
                return ItemMasterRepository.Find(i => i.ItemMasterId == masterid).Select(c => c.ItemMasterDefinition).SelectMany(i => i.ItemMaster).AsExpandable().
                    Select(i => Master.ParseItemExp.Invoke(i));
            }
            return null;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// AllByFacility operation
        /// </summary>
        public IQueryable<Master> AllByFacility(short facilityId)
        {
            return ContainerMasterRepository.All().Where(i => i.ContainerMasterDefinition.CustomerDefinition.Customer.FirstOrDefault().FacilityId == facilityId).AsExpandable().
                Select(i => Master.ParseContainerExp.Invoke(i)).
                Concat
                (
                    ItemMasterRepository.All().AsExpandable().
                        Select(i => Master.ParseItemExp.Invoke(i))
                );
        }

        /// <summary>
        /// Method to get deleted item type active item summaray details for a facility
        /// </summary>
        /// <param name="facilityId">selected facility</param>
        /// <param name="deletedItemTypes">list of deleted item types</param>
        /// <returns></returns>
        /// <summary>
        /// GetDeletedItemTypeActiveItemSummaryDetails operation
        /// </summary>
        public List<ItemTypeSummaryDetail> GetDeletedItemTypeActiveItemSummaryDetails(short facilityId, List<short> deletedItemTypes)
        {
            using (var repo = new PathwayRepository())
            {
                const int customerActive = (int)CustomerStatusTypeIdentifier.Active;
                const byte itemActive = (byte)ItemStatusTypeIdentifier.Active;

                var customers = repo.Container.Customer
                    .Where(c => c.FacilityId == facilityId && c.Revision == c.CustomerDefinition.Customer.OrderByDescending(cMax => cMax.Revision).FirstOrDefault().Revision)
                    .Where(c => c.CustomerStatusId == customerActive);

                var containerMasterDefinitions = customers
                    .SelectMany(c => c.CustomerDefinition.ContainerMasterDefinition)
                    .Select(cmd => cmd.ContainerMasterDefinitionId);

                var containerMasters =
                    from cm in repo.Container.ContainerMaster
                    join cmd in containerMasterDefinitions on cm.ContainerMasterDefinitionId equals cmd
                    where cm.Revision == cm.ContainerMasterDefinition.ContainerMasters.OrderByDescending(cmMax => cmMax.Revision).FirstOrDefault().Revision
                    select cm;

                var containerMasterItemTypes =
                    from cm in containerMasters
                    where cm.ItemStatusId == itemActive && deletedItemTypes.Contains(cm.ItemTypeId)
                    select cm.ItemType;

                var deletedContainerMasterItemTypes = containerMasterItemTypes.Where(a => deletedItemTypes.Contains(a.ItemTypeId)).Distinct().ToList();

                var itemMasterDefinitions = containerMasters.SelectMany(cm => cm.ContainerContents).Select(cc => cc.ItemMasterDefinitionId).Distinct();

                var itemMasters = (
                    from im in repo.Container.ItemMaster
                    join imd in itemMasterDefinitions on im.ItemMasterDefinitionId equals imd
                    where im.Revision == im.ItemMasterDefinition.ItemMaster.OrderByDescending(imMax => imMax.Revision).FirstOrDefault().Revision
                    select im
                ).Where(im => im.ItemStatusId == itemActive && deletedItemTypes.Contains(im.ItemTypeId)).Distinct();

                var deletedItemMasterItemTypes = itemMasters.Where(a => deletedItemTypes.Contains(a.ItemTypeId)).Select(a=> a.ItemType).Distinct().ToList();

                var results = new List<ItemTypeSummaryDetail>();

                results.AddRange(deletedContainerMasterItemTypes.Select(a => new ItemTypeSummaryDetail
                {
                    ItemTypeId = a.ItemTypeId,
                    ItemTypeName = a.Text,
                    ActiveItemCount = 1,
                    ParentItemTypeId = a.ParentItemTypeId,
                    ParentItemTypeName = a.ParentItemType.Text
                }));

                results.AddRange(deletedItemMasterItemTypes.Select(a => new ItemTypeSummaryDetail
                {
                    ItemTypeId = a.ItemTypeId,
                    ItemTypeName = a.Text,
                    ActiveItemCount = 1,
                    ParentItemTypeId = a.ParentItemTypeId,
                    ParentItemTypeName = a.ParentItemType.Text
                }));

                return results;
            }
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public IList<Master> Get(int masterId, MasterType masterType)
        {
            IList<Master> masters = new List<Master>();
            if (masterType == MasterType.ContainerMaster || masterType == MasterType.None)
            {
                var cms = ContainerMasterRepository.Find(m => m.ContainerMasterId == masterId)
                    .Include("ContainerMasterDefinition.CustomerDefinition.CurrentCustomer.Facility")
                    .Include("ItemType.ParentItemType")
                    .Include("ProcessingDecontaminationTasks")
                    .ToList();

                var cm = cms
                    .Select(i => new Master
                    {
                        ContainerMaster = i,
                        ItemMaster = null,
                        MasterId = i.ContainerMasterId,
                        Name = i.Text,
                        CreatedDate = i.Created,
                        IndependentQualityAssuranceCheck = i.IndependentQualityAssuranceCheck,
                        Revision = i.Revision,
                        SpecialityId = i.SpecialityId,
                        CategoryId = i.CategoryId,
                        CreatedUserId = i.CreatedUserId,
                        ItemTypeId = i.ItemTypeId,
                        ComplexityId = i.ComplexityId,
                        ItemStatusId = i.ItemStatusId,
                        DefinitionId = i.ContainerMasterDefinitionId,
                        ManufacturersReference = i.ManufacturersReference,
                        NumberOfLabels = i.NumberOfLabels,
                        LegacyInternalId = i.LegacyId,
                        ExternalId = i.ExternalId,
                        BatchCycleId = i.ChargableBatchCycleId,
                        PrinterTypeId = i.PrinterTypeId,
                        ComponentPartCount = default(short),
                        MachineType = i.MachineTypeId,
                        Gtin = i.Gtin,
                        ComplianceReasonId = i.PinRequestReasonId,
                        Archived = i.Archived,
                        ProcessingBatchCycles = i.ProcessingBatchCycles,
                        CustomerDefinitionId = i.ContainerMasterDefinition.CustomerDefinitionId,
                        CustomerName = i.ContainerMasterDefinition.CustomerDefinition.CurrentCustomer.Text,
                        BaseItemTypeId = i.ItemType.ParentItemTypeId.GetValueOrDefault(),
                        BaseItemTypeName = i.ItemType.ParentItemType.Text,
                        FacilityName = i.ContainerMasterDefinition.CustomerDefinition.CurrentCustomer.Facility.Text,
                        ProcessingDecontaminationTasks = i.ProcessingDecontaminationTasks,
                        LabourLevelId = i.LabourLevelId,
                        CoolingTime = i.CoolingTime,
                        QualityId = i.ContainerMasterDefinition?.ContainerMasterQualityId ?? default(short),
                        QualityTypeId = i.ContainerMasterDefinition?.Quality.QualityTypeId?? default(short),
                        DefinitionTypeId = i.ContainerMasterDefinition?.ContainerMasterDefinitionTypeId ?? default(short),
                        IsTrayChangeChargeable = i.ContainerMasterDefinition.CustomerDefinition.ChargeList.Where(cl  => cl.Archived == null && cl.ChargeListCategoryId == (byte)ChargeListCategoryIdentifier.ChangeControlNote).Count() > 0 ,

                    })
                    .SingleOrDefault();

                if (cm != null)
                    masters.Add(cm);
            }
            if (masterType == MasterType.ItemMaster || masterType == MasterType.None)
            {
                var imr = ItemMasterRepository.Find(m => m.ItemMasterId == masterId)
                    .Include("ItemMasterDefinition")
                    .Include("Manufacturer")
                    .SingleOrDefault();
                var im = new Master
                {
                    ContainerMaster = null,
                    ItemMaster = imr,
                    MasterId = imr.ItemMasterId,
                    Name = imr.Text,
                    CreatedDate = imr.Created,
                    IndependentQualityAssuranceCheck = imr.IndependentQualityAssuranceCheck,
                    Revision = imr.Revision,
                    SpecialityId = imr.SpecialityId,
                    CategoryId = imr.CategoryId,
                    CreatedUserId = imr.CreatedUserId,
                    ItemTypeId = imr.ItemTypeId,
                    ComplexityId = imr.ComplexityId,
                    ItemStatusId = imr.ItemStatusId,
                    DefinitionId = imr.ItemMasterDefinitionId,
                    ManufacturersReference = imr.ManufacturersReference,
                    NumberOfLabels = default(byte),
                    LegacyInternalId = imr.LegacyId,
                    ExternalId = imr.ExternalId,
                    BatchCycleId = imr.BatchCycleId,
                    PrinterTypeId = default(byte),
                    ComponentPartCount = imr.ComponentPartCount,
                    MachineType = default(byte),
                    Gtin = null,
                    ComplianceReasonId = imr.PinRequestReasonId,
                    Archived = null,
                    ProcessingBatchCycles = imr.ProcessingBatchCycles,
                    BaseItemTypeId = (short)imr.ItemType.ParentItemTypeId,
                    BaseItemTypeName = imr.ItemType.ParentItemType.Text,
                    Manufacturer = imr.Manufacturer != null ? new DataContracts.ManufacturerDataContract { ManufacturerId = imr.Manufacturer.ManufacturerId, Name = imr.Manufacturer.Name } : null,
                    QualityId = imr.ItemMasterDefinition?.ItemMasterQualityId ?? default(short),
                    QualityTypeId = imr.ItemMasterDefinition?.Quality.QualityTypeId?? default(short),
                    DefinitionTypeId = imr.ItemMasterDefinition?.ItemMasterDefinitionTypeId?? default(short),
                };

                if (im != null)
                    masters.Add(im);
            }
            return masters.ToList();

        }
        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetByDefinition operation
        /// </summary>
        public IList<Master> GetByDefinition(int masterDefinitionId, MasterType masterType)
        {

            IList<Master> masters = new List<Master>();
            if (masterType == MasterType.ContainerMaster || masterType == MasterType.None)
                foreach (var containerMaster in ContainerMasterRepository.Find(m => m.ContainerMasterDefinitionId == masterDefinitionId && m.ItemStatusId == (short)ItemStatusId.Active).AsExpandable())
                {
                    var master = Master.ParseContainerExp.Invoke(containerMaster);
                    if (containerMaster.ContainerMasterDefinition != null)
                    {
                        master.CustomerDefinitionId = containerMaster.ContainerMasterDefinition != null
                                                          ? containerMaster.ContainerMasterDefinition.CustomerDefinitionId
                                                          : default(int);
                        var customer = containerMaster.ContainerMasterDefinition.CustomerDefinition.Customer.OrderByDescending(i => i.Revision).FirstOrDefault();
                        master.CustomerName = customer != null ? customer.Text : string.Empty;
                        master.FacilityName = customer != null ? customer.Facility.Text : string.Empty;
                    }
                    masters.Add(master);
                }
            if (masterType == MasterType.ItemMaster || masterType == MasterType.None)
                return masters.Concat
                    (
                        ItemMasterRepository.Find(m => m.ItemMasterId == masterDefinitionId && m.ItemStatusId == (short)ItemStatusId.Active).AsExpandable().
                            Select(i => Master.ParseItemExp.Invoke(i))
                    ).ToList();
            else
            {
                return masters.ToList();
            }
        }

        /// <summary>
        /// Returns the ItemMaster search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// SearchItems operation
        /// </summary>
        public IList<Master> SearchItems(string searchText, short facilityId, DataFilter filter)
        {
            string externalId = null;
            string text = null;
            string baseItemTypeNameText = null;
            string childItemTypeNameText = null;
            foreach (var keyValuePair in
                            filter.ToKeyValuePairList().Where(keyValuePair => !string.IsNullOrEmpty(keyValuePair.Value)))
            {
                switch (keyValuePair.Key)
                {
                    case "ExternalId":
                        externalId = keyValuePair.Value;
                        break;
                    case "Text":
                        text = keyValuePair.Value;
                        break;
                    case "BaseItemTypeName":
                        baseItemTypeNameText = keyValuePair.Value;
                        break;
                    case "ChildItemTypeName":
                        childItemTypeNameText = keyValuePair.Value;
                        break;
                }
            }
            var items = new List<Master>();

            using (var context = new OperativeModelContainer())
            {
                items.AddRange(context.admapp_ReadPagedItemMasters(facilityId, searchText, null, externalId, text, baseItemTypeNameText, childItemTypeNameText, filter.SortAscending, filter.SortColumn, filter.ItemsPerPage, filter.CurrentPageIndex).Select(item =>
                    new Master()
                    {
                        MasterId = item.ItemMasterId,
                        DefinitionId = item.ItemMasterDefinition,
                        ExternalId = item.ItemId,
                        Name = item.Text,
                        BaseItemTypeName = item.BaseType,
                        ChildItemTypeName = item.SubType,
                        Total = item.TotalRows ?? default(int)
                    }));
            }

            return items;
        }

        /// <summary>
        /// ReadPagedMasters operation
        /// </summary>
        public IList<MasterData> ReadPagedMasters(MasterParametersData masterParameters, UserCultureData userCultureData)
        {
            var items = new List<MasterData>();

            using (var repository = new PathwayRepository())
            {
                var result = repository.DataManager.ExecuteQuery((row, table, set) =>
                {
                    return new PagedMasters_Result
                    {
                        MasterType = Convert.ToInt32(row["MasterType"]),
                        MasterId = Convert.ToInt32(row["MasterId"]),
                        ItemId = row["ItemID"].ToString(),
                        Text = row["text"].ToString(),
                        BaseType = row["BaseType"].ToString(),
                        SubType = row["SubType"].ToString(),
                        TotalRows = Convert.ToInt32(row["TotalRows"]),
                        CustomerName = row["customername"].ToString(),
                        Quality = row["Quality"].ToString(),
                        QualityID = row["QualityID"] != null ? (short?)Convert.ToInt32(row["QualityID"]) : null
                    };
                },
                    "dbo.admapp_ReadPagedMasters_Translated",
                    CommandType.StoredProcedure,
                    new SqlParameter("ItemTypeId", masterParameters.ItemTypeId),
                    new SqlParameter("FacilityId", masterParameters.FacilityId),
                    new SqlParameter("ExternalId", masterParameters.ExternalId),
                    new SqlParameter("BaseType", masterParameters.BaseItemTypeName),
                    new SqlParameter("SubType", masterParameters.ChildItemTypeName),
                    new SqlParameter("Text", masterParameters.Text),
                    new SqlParameter("CustomerName", masterParameters.CustomerName),
                    new SqlParameter("IsAscending", masterParameters.PagingSortingFilters.SortAscending),
                    new SqlParameter("SortField", masterParameters.PagingSortingFilters.SortColumn),
                    new SqlParameter("PageSize", masterParameters.PagingSortingFilters.ItemsPerPage),
                    new SqlParameter("PageIndex", masterParameters.PagingSortingFilters.CurrentPageIndex),
                    CultureHelper.CreateUserCultureData(userCultureData)
                );

                foreach (var item in result)
                {
                    items.Add(new MasterData()
                    {
                        MasterType = (MasterType)Enum.Parse(typeof(MasterType), item.MasterType.ToString()),
                        MasterId = item.MasterId,
                        ExternalId = item.ItemId,
                        Text = item.Text,
                        BaseItemTypeName = item.BaseType,
                        ChildItemTypeName = item.SubType,
                        Total = item.TotalRows,
                        CustomerName = item.CustomerName,
                        QualityId = item.QualityID ?? (short)QualityIdentifier.Standard//if query returned null then quality is irrelevant
                    });
                }
            }
            return items;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAlerts operation
        /// </summary>
        public IList<DashboardItem> GetAlerts(short facilityId)
        {

            {
                var result = context.admapp_ReadAlerts(facilityId);
                return result.Select(item => new DashboardItem
                {
                    Identifier = item.Identifier,
                    ItemId = item.ItemId,
                    ItemDescription = item.ItemDescription,
                    SynergyItemType = (item.SynergyItemType == 0 ? EntityType.Container :
                        (item.SynergyItemType == 1 ? EntityType.Item :
                        (item.SynergyItemType == 2 ? EntityType.Defects : EntityType.CustomerDefects)))
                }).ToList();
            }
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetDashboardSummary operation
        /// </summary>
        public DashboardSummaryData GetDashboardSummary(short facilityId)
        {

            {
                var result = context.admapp_ReadkeyStatistics(facilityId);
                return result.Select(item => new DashboardSummaryData
                {
                    ItemsProcessed = item.ItemsProcessed ?? default(int),
                    QuarantineItems = item.Quarantineevents ?? default(int),
                    OverdueItems = item.OverdueItems ?? default(int),
                    OutstandingSynergyDefects = item.OutstandingSynergyDefects ?? default(int),
                    CustomerDefectsAwaitingResponse = item.CustomerDefectsAwaitingResponse ?? default(int),
                    FastTrackRequests = item.FastTrackRequests ?? default(int),

                }).FirstOrDefault();
            }
        }

        /// <summary>
        /// ReadByItemType operation
        /// </summary>
        public IList<Master> ReadByItemType(int itemTypeId, short facilityId, Synergy.Core.Data.DataFilter filter, UserCultureData userCultureData)
        {          
            {
                var result = repository.DataManager.ExecuteQuery((row, table, set) =>
                {
                    return new PagedMasters_Result
                    {
                        MasterType = Convert.ToInt32(row["MasterType"]),
                        MasterId = Convert.ToInt32(row["MasterId"]),
                        ItemId = row["ItemID"].ToString(),
                        Text = row["text"].ToString(),
                        BaseType = row["BaseType"].ToString(),
                        SubType = row["SubType"].ToString(),
                        TotalRows = Convert.ToInt32(row["TotalRows"]),
                        CustomerName = row["customername"].ToString(),
                        DefinitionId = Convert.ToInt32(row["DefinitionId"]),
                        Quality = row["Quality"].ToString(),
                        QualityID = row["QualityID"] != null ? (short?)Convert.ToInt32(row["QualityID"]) : null
                    };
                },
                    "dbo.admapp_ReadPagedMasters_Translated",
                    CommandType.StoredProcedure,
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("facilityId", facilityId),
                    new SqlParameter("ExternalId", filter.SearchItems.Count > 0 ? filter.SearchItems.Where(i => i.PropertyAlias == "ContainerMasterExternalId").FirstOrDefault().Value : null),
                    new SqlParameter("BaseType", filter.SearchItems.Count > 0 ? filter.SearchItems.Where(i => i.PropertyAlias == "BaseItemTypeText").FirstOrDefault().Value : null),
                    new SqlParameter("SubType", null),
                    new SqlParameter("Text", filter.SearchItems.Count > 0 ? filter.SearchItems.Where(i => i.PropertyAlias == "ContainerMasterText").FirstOrDefault().Value : null),
                    new SqlParameter("CustomerName", filter.SearchItems.Count > 0 ? filter.SearchItems.Where(i => i.PropertyAlias == "CustomerName").FirstOrDefault().Value : null),
                    new SqlParameter("IsAscending", filter.OrderByAscending),
                    new SqlParameter("SortField", (filter.OrderBy == "ContainerMasterText" ? "Text" : filter.OrderBy)),
                    new SqlParameter("PageSize", filter.Take),
                    new SqlParameter("PageIndex", (filter.Skip + filter.Take) / filter.Take),
                    CultureHelper.CreateUserCultureData(userCultureData)
                );

                
                var qualitySearchTerm = filter.SearchItems.Where(si => si.PropertyAlias == "QualityName").FirstOrDefault()?.Value?.ToLower();                

                if (!string.IsNullOrEmpty(qualitySearchTerm))
                {
                    result = result.Where(m => TranslatorManager.GetText("entities", "dbo.Quality",m.Quality).ToLower().Contains(qualitySearchTerm)).ToList();
                }

                IQueryable<Master> query= result.Select(item => new Master
                    {
                        ExternalId = item.ItemId,
                        Name = item.Text,
                        BaseItemTypeName = item.BaseType,
                        MasterId = item.MasterId,
                        Total = item.TotalRows,
                        ContainerMaster = ((MasterType)item.MasterType == MasterType.ContainerMaster) ? new ContainerMaster() { ContainerMasterId = item.MasterId } : null,
                        ItemMaster = ((MasterType)item.MasterType == MasterType.ItemMaster) ? new ItemMaster() { ItemMasterId = item.MasterId } : null,
                        CustomerName = item.CustomerName,
                        DefinitionId = item.DefinitionId,
                        QualityId = item.QualityID ?? (short)QualityIdentifier.Standard, //if quality returned null then it's irrelevant
                    QualityTypeId = item.QualityTypeID?? (short)QualityTypeIdentifier.Standard 
                }).AsQueryable();

                return query.ToList();
            }
            }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetByDefinitionAndLatestRevision operation
        /// </summary>
        public IList<Master> GetByDefinitionAndLatestRevision(int masterDefinitionId, MasterType masterType)
        {
            IList<Master> masters = new List<Master>();
            if (masterType == MasterType.ContainerMaster || masterType == MasterType.None)
            {
                ContainerMaster containerMaster = ContainerMasterRepository.Find(m => m.ContainerMasterDefinitionId == masterDefinitionId).OrderByDescending(i => i.Revision).FirstOrDefault();
                var master = Master.ParseContainerExp.Invoke(containerMaster);
                if (containerMaster.ContainerMasterDefinition != null)
                {
                    master.CustomerDefinitionId = containerMaster.ContainerMasterDefinition != null
                                                      ? containerMaster.ContainerMasterDefinition.CustomerDefinitionId
                                                      : default(int);
                    var customer = containerMaster.ContainerMasterDefinition.CustomerDefinition.Customer.FirstOrDefault();
                    master.CustomerName = customer != null ? customer.Text : string.Empty;
                    master.FacilityName = customer != null ? customer.Facility.Text : string.Empty;
                    master.IsTrayChangeChargeable = customer.CustomerDefinition.ChargeList.Where(cl => cl.Archived == null).ToList().Count > 0;
                    master.DefinitionTypeId = containerMaster.ContainerMasterDefinition.ContainerMasterDefinitionTypeId;
                }
                masters.Add(master);
            }
            if (masterType == MasterType.ItemMaster || masterType == MasterType.None)
            {
                ItemMaster itemMaster = ItemMasterRepository.Find(m => m.ItemMasterDefinitionId == masterDefinitionId).OrderByDescending(i => i.Revision).FirstOrDefault();
                var imaster = Master.ParseItemExp.Invoke(itemMaster);
                imaster.DefinitionTypeId = itemMaster.ItemMasterDefinition.ItemMasterDefinitionTypeId;
                masters.Add(imaster);
            }

            return masters.ToList();
        }
    }
}