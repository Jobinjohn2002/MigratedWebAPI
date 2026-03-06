using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// Defect Repository
    /// </summary>
    /// <remarks></remarks>
    public partial class DefectRepository
    {
        /// <summary>
        /// Gets the specified defect Id.
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public Defect Get(int defectId)
        {
            return Repository.Find(defect => defect.DefectId == defectId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the defect by instance last turnaround uid.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetDefectByInstanceLastTurnaroundId operation
        /// </summary>
        public Defect GetDefectByInstanceLastTurnaroundId(int turnaroundId)
        {
            return Repository.Find(d => d.TurnaroundId == turnaroundId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the defect by turnaround uid by date.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetDefectByTurnaroundIdByDate operation
        /// </summary>
        public IQueryable<Defect> GetDefectByTurnaroundIdByDate(int turnaroundId, DateTime startDate, DateTime endDate)
        {
            var turnaroundRepository = TurnaroundRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());

            if (startDate > DateTime.MinValue && endDate > DateTime.MinValue)
            {
                return turnaroundRepository.Repository.All()
                    .Where(t => t.TurnaroundId == turnaroundId)
                    .SelectMany(turn => turn.Defect)
                    .Where(defect =>
                           defect.Raised >= startDate && defect.Raised <= endDate &&
                           defect.DefectStatusId != (int)DefectStatusIdentifier.Closed);
            }
            return turnaroundRepository.Repository.All()
                .Where(t => t.TurnaroundId == turnaroundId)
                .SelectMany(turn => turn.Defect).Where(
                    defect => defect.DefectStatusId != (int)DefectStatusIdentifier.Closed);
        }

        /// <summary>
        /// ReadOpenDefectsWithAutomaticQuarantineByTurnaroundId operation
        /// </summary>
        public IEnumerable<Defect> ReadOpenDefectsWithAutomaticQuarantineByTurnaroundId(int turnaroundId)
        {
            return GetOpenDefects(turnaroundId).Where(d => d.QuarantineAfterWash);
        }

        /// <summary>
        /// GetOpenDefects operation
        /// </summary>
        public IEnumerable<Defect> GetOpenDefects(int turnaroundId)
        {
            var turnaroundRepository = TurnaroundRepository.New(Repository.UnitOfWork);

            var openDefectsOnPreviousTurnaround = turnaroundRepository.Repository.Find(t => t.TurnaroundId == turnaroundId).SelectMany(t => t.ContainerInstance.Turnaround.Where(x => x.TurnaroundId != turnaroundId).OrderByDescending(x => x.Created).Take(1).SelectMany(x => x.Defect.Where(d => d.DefectStatusId == (int)DefectStatusIdentifier.New || d.DefectStatusId == (int)DefectStatusIdentifier.UnderInvestigation))).ToList();

            var openDefectsOnCurrentTurnaround = Repository.Find(d => d.TurnaroundId == turnaroundId && (d.DefectStatusId == (int)DefectStatusIdentifier.New || d.DefectStatusId == (int)DefectStatusIdentifier.UnderInvestigation)).ToList();

            return openDefectsOnPreviousTurnaround.Concat(openDefectsOnCurrentTurnaround);
        }

        /// <summary>
        /// Reads the defects by definition.
        /// </summary>
        /// <param name="definitionId">The definition id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadDefectsByDefinition operation
        /// </summary>
        public IQueryable<Defect> ReadDefectsByDefinition(int definitionId)
        {
            var latestList = Repository.Find(d => d.ContainerInstance.ContainerMasterDefinitionId == definitionId
                || d.ContainerMaster.ContainerMasterDefinitionId == definitionId
                || d.Turnaround.ContainerMaster.ContainerMasterDefinitionId == definitionId)
                .GroupBy(i => i.ExternalId).SelectMany(c => c.OrderByDescending(r => r.Raised).Take(1));

            var earliestList = Repository.Find(d => d.ContainerInstance.ContainerMasterDefinitionId == definitionId
                || d.ContainerMaster.ContainerMasterDefinitionId == definitionId
                || d.Turnaround.ContainerMaster.ContainerMasterDefinitionId == definitionId)
                .GroupBy(i => i.ExternalId).SelectMany(c => c.OrderBy(r => r.Raised).Take(1));

            var results = from latest in latestList
                join earliest in earliestList on latest.ExternalId equals earliest.ExternalId
                select new
                {
                    latest.DefectId,
                    latest.ContainerInstanceId,
                    latest.CreatedUserId,
                    latest.DefectClassificationId,
                    latest.DefectResponsibilityId,
                    latest.DefectSeverityId,
                    latest.DefectStatusId,
                    latest.DeliveryPointId,
                    latest.DeliveryPoint,
                    latest.ImmediateActionUserId,
                    latest.LongTermActionUserId,
                    latest.ReviewUserId,
                    latest.TurnaroundId,
                    latest.SignedForSynergyUserId,
                    latest.ExternalId,
                    earliest.Raised,
                    latest.Received,
                    latest.ReportingDepartment,
                    latest.ReporterUserName,
                    latest.ReporterUserPosition,
                    latest.ItemName,
                    latest.GeneralFaultCount,
                    latest.OtherDetails,
                    latest.ImmediateAction,
                    latest.ImmediateActionDate,
                    latest.LongTermAction,
                    latest.LongTermActionDate,
                    latest.SignedForTrustUserName,
                    latest.ReviewInformation,
                    latest.Reviewed,
                    latest.LegacyId,
                    latest.LegacyFacilityOrigin,
                    latest.LegacyImported,
                    latest.ContainerMasterId,
                    latest.IncidentDate,
                    latest.DefectSourceId,
                    latest.UnTrackedProductId,
                    latest.CustomSeverityId,
                    latest.CustomClassificationId
                };

            var resultsList = results.ToList().Select(def => new Defect
            {
                DefectId = def.DefectId,
                ContainerInstanceId = def.ContainerInstanceId,
                CreatedUserId = def.CreatedUserId,
                DefectClassificationId = def.DefectClassificationId,
                DefectResponsibilityId = def.DefectResponsibilityId,
                DefectSeverityId = def.DefectSeverityId,
                DefectStatusId = def.DefectStatusId,
                DeliveryPointId = def.DeliveryPointId,
                DeliveryPoint = def.DeliveryPoint,
                ImmediateActionUserId = def.ImmediateActionUserId,
                LongTermActionUserId = def.LongTermActionUserId,
                ReviewUserId = def.ReviewUserId,
                TurnaroundId = def.TurnaroundId,
                SignedForSynergyUserId = def.SignedForSynergyUserId,
                ExternalId = def.ExternalId,
                Raised = def.Raised,
                Received = def.Received,
                ReportingDepartment = def.ReportingDepartment,
                ReporterUserName = def.ReporterUserName,
                ReporterUserPosition = def.ReporterUserPosition,
                ItemName = def.ItemName,
                GeneralFaultCount = def.GeneralFaultCount,
                OtherDetails = def.OtherDetails,
                ImmediateAction = def.ImmediateAction,
                ImmediateActionDate = def.ImmediateActionDate,
                LongTermAction = def.LongTermAction,
                LongTermActionDate = def.LongTermActionDate,
                SignedForTrustUserName = def.SignedForTrustUserName,
                ReviewInformation = def.ReviewInformation,
                Reviewed = def.Reviewed,
                LegacyId = def.LegacyId,
                LegacyFacilityOrigin = def.LegacyFacilityOrigin,
                LegacyImported = def.LegacyImported,
                ContainerMasterId = def.ContainerMasterId,
                IncidentDate = def.IncidentDate,
                DefectSourceId = def.DefectSourceId,
                UnTrackedProductId = def.UnTrackedProductId,
                CustomSeverityId = def.CustomSeverityId,
                CustomClassificationId = def.CustomClassificationId,
            }).ToList();

            foreach (var i in resultsList)
            {
                i.EntityKeyValue = i.DefectId.ToString();
            }

            return resultsList.AsQueryable();
        }

        /// <summary>
        /// ReadAllDefectsByFacilityAndDefectStatus operation
        /// </summary>
        public IQueryable<Defect> ReadAllDefectsByFacilityAndDefectStatus(short facilityId, bool isClose)
        {
            return isClose ? Repository.Find(d => d.DefectStatusId == (byte)DefectStatusIdentifier.Closed && d.DeliveryPoint.CustomerDefinition.Customer.Any(i => i.FacilityId == facilityId)) :
                             Repository.Find(d => d.DefectStatusId != (byte)DefectStatusIdentifier.Closed && d.DeliveryPoint.CustomerDefinition.Customer.Any(i => i.FacilityId == facilityId));
        }

        /// <summary>
        /// Reads the defects by definition.
        /// </summary>
        /// <param name="customerDefectAssociationType"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadDetailsOfProduct operation
        /// </summary>
        public IList<IGenericKeyValue> ReadDetailsOfProduct(CustomerDefectAssociationType customerDefectAssociationType, string itemId, short facilityId)
        {
            var result = new List<IGenericKeyValue>();
            switch (customerDefectAssociationType)
            {

                case CustomerDefectAssociationType.Turnaround:
                    var turnaroundRepository = TurnaroundRepository.New(
                                                                                 UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
                    var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacilityId(long.Parse(itemId), facilityId);

                    if (turnaround != null)
                    {
                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.Turnaround.ToString(), Name = turnaround.ExternalId.ToString() });
                        result.Add(new GenericKeyValue
                            {
                                Tag = CustomerDefectAssociationType.CustomerDefinition.ToString(),
                                Name = turnaround.DeliveryPoint.Text,
                                Id = turnaround.DeliveryPoint.CustomerDefinitionId
                            });
                        result.Add(new GenericKeyValue
                            {
                                Tag = CustomerDefectAssociationType.DeliveryPoint.ToString(),
                                Name = turnaround.DeliveryPoint.Text,
                                Id = turnaround.DeliveryPointId
                            });
                        if (turnaround.ContainerMaster != null)
                        {
                            result.Add(new GenericKeyValue
                            {
                                Tag = CustomerDefectAssociationType.ContainerMaster.ToString(),
                                Name = turnaround.ContainerMaster.ExternalId.ToString()
                            });
                            result.Add(new GenericKeyValue { Tag = "ContainerMasterAutoId", Name = turnaround.ContainerMaster.ContainerMasterId.ToString() });
                            result.Add(new GenericKeyValue { Tag = "ContainerMasterName", Name = turnaround.ContainerMaster.Text });
                        }
                        if (turnaround.ContainerInstance != null)
                        {
                            result.Add(new GenericKeyValue
                            {
                                Tag = CustomerDefectAssociationType.ContainerInstance.ToString(),
                                Name = turnaround.ContainerInstance.PrimaryId
                            });
                            result.Add(new GenericKeyValue() { Tag = "ContainerInstanceAutoId", Name = turnaround.ContainerInstance.ContainerInstanceId.ToString() });
                        }

                        result.Add(new GenericKeyValue() { Tag = "TurnaroundAutoId", Name = turnaround.TurnaroundId.ToString() });
                    }
                    break;

                case CustomerDefectAssociationType.ContainerMaster:
                    var containerMasterRepository = ContainerMasterRepository.New(
                                                                                 UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
                    var containerMaster = containerMasterRepository.GetContainerMasterUsingExternalId(itemId);

                    if (containerMaster != null)
                    {
                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.Turnaround.ToString(), Name = string.Empty });
                        result.Add(new GenericKeyValue { Tag = "ContainerMasterAutoId", Name = containerMaster.ContainerMasterId.ToString() });
                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.ContainerMaster.ToString(), Name = containerMaster.ExternalId });
                        result.Add(new GenericKeyValue { Tag = "ContainerMasterName", Name = containerMaster.Text });
                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.ContainerInstance.ToString(), Name = string.Empty });
                    }
                    break;

                case CustomerDefectAssociationType.ContainerInstance:
                    var containerInstanceRepository = ContainerInstanceRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());

                    var containerInstance = containerInstanceRepository.GetByPrimaryAndFacilityId(itemId, facilityId);

                    if (containerInstance != null)
                    {
                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.Turnaround.ToString(), Name = string.Empty });
                        if (containerInstance.ContainerMasterDefinition.ContainerMasters != null)
                        {
                            result.Add(new GenericKeyValue
                            {
                                Tag = CustomerDefectAssociationType.ContainerMaster.ToString(),
                                Name =
                                    containerInstance.ContainerMasterDefinition.ContainerMasters.FirstOrDefault().ExternalId
                            });
                            result.Add(new GenericKeyValue
                            {
                                Tag = "ContainerMasterAutoId",
                                Name = containerInstance.ContainerMasterDefinition.ContainerMasters.FirstOrDefault().ContainerMasterId.ToString()

                            });
                            result.Add(new GenericKeyValue
                            {
                                Tag = "ContainerMasterName",
                                Name = containerInstance.ContainerMasterDefinition.ContainerMasters.FirstOrDefault().Text
                            });
                        }

                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.ContainerInstance.ToString(), Name = containerInstance.PrimaryId });

                        result.Add(new GenericKeyValue { Tag = "ContainerInstanceAutoId", Name = containerInstance.ContainerInstanceId.ToString() });
                        
                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.CustomerDefinition.ToString(), Name = containerInstance.DeliveryPoint.CustomerDefinitionId.ToString() });
                        result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.DeliveryPoint.ToString(), Name = containerInstance.DeliveryPointId.ToString() });
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// Reads the defects by definition.
        /// </summary>
        /// <param name="customerDefectAssociationType"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadDetailsOfProductForMaintenance operation
        /// </summary>
        public IList<IGenericKeyValue> ReadDetailsOfProductForMaintenance(CustomerDefectAssociationType customerDefectAssociationType, string itemId, int facilityId)
        {
            var result = new List<IGenericKeyValue>();
            var turnaroundRepository = TurnaroundRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            
            Turnaround turnaround;
            var containerMasterRepository = ContainerMasterRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            IContainerMaster containerMaster;
            var containerInstanceRepository = ContainerInstanceRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            var maintenanceReportRepository = OwnerMaintenanceReportSettingRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());

            ContainerInstance containerInstance;
            switch (customerDefectAssociationType)
            {
                case CustomerDefectAssociationType.Turnaround:
                    try
                    {
                        using (var repository = new PathwayRepository())
                        {
                            var externalId = Convert.ToInt64(itemId);
                            var primaryFacility = (from t in repository.Container.Turnaround
                                                   join cm in repository.Container.ContainerMaster on t.ContainerMasterId equals cm.ContainerMasterId
                                                   join cmd in repository.Container.ContainerMasterDefinition on cm.ContainerMasterDefinitionId equals cmd.ContainerMasterDefinitionId
                                                   join ci in repository.Container.ContainerInstance on cmd.ContainerMasterDefinitionId equals ci.ContainerMasterDefinitionId
                                                   join c in repository.Container.Customer on cmd.CustomerDefinitionId equals c.CustomerDefinitionId
                                                   where t.ExternalId == externalId
                                                   select c.FacilityId).FirstOrDefault();

                            if ((primaryFacility == facilityId) ||
                                (IsSecondaryFacility(facilityId, repository, primaryFacility)))
                            {
                                turnaround =
                                    turnaroundRepository.GetTurnaroundByExternalIdAndFacility(Convert.ToInt64(itemId));
                                if (turnaround != null)
                                {
                                    var maintenanceSetting = maintenanceReportRepository.GetMaintenanceReportSettingByCustomerDefinition(turnaround.DeliveryPoint.CustomerDefinitionId, MaintenanceTypeIdentifier.Repair);

                                    if (maintenanceSetting == Enums.MaintenanceReportSetting.Off)
                                    {
                                        result.Add(new GenericKeyValue
                                        {
                                            Tag = "ErrorMsgRepairsDisabled",
                                            Name = "Repairs are off for this customer."
                                        });
                                    }
                                    else
                                    {
                                        if (maintenanceSetting == Enums.MaintenanceReportSetting.Suspended)
                                        {
                                            result.Add(new GenericKeyValue
                                            {
                                                Tag = "WarningMsgRepairsSuspended",
                                                Name = "Warning: repairs are suspended for this customer."
                                            });
                                        }

                                        SetProductValuesWithTurnaroundData(turnaround, result);
                                    }
                                }
                                else
                                {
                                    result.Add(new GenericKeyValue
                                    {
                                        Tag = "ErrorMsgValidTurnaround",
                                        Name = "Please enter valid Turnaround ID."
                                    });
                                }
                            }
                            else
                            {
                                result.Add(new GenericKeyValue { Tag = "ErrorMsgValidTurnaround", Name = "Please enter valid Turnaround ID." });
                            }
                        }
                    }
                    catch
                    {
                        result.Add(new GenericKeyValue { Tag = "ErrorMsgValidTurnaround", Name = "Please enter valid Turnaround ID." });
                    }
                    break;
                case CustomerDefectAssociationType.TurnaroundAutoId:
                    turnaround = null;
                    {
                        var turnaroundId = int.Parse(itemId);
                        var primaryFacility = (from t in repository.Container.Turnaround
                                               join cm in repository.Container.ContainerMaster on t.ContainerMasterId equals cm.ContainerMasterId
                                               join cmd in repository.Container.ContainerMasterDefinition on cm.ContainerMasterDefinitionId equals cmd.ContainerMasterDefinitionId
                                               join ci in repository.Container.ContainerInstance on cmd.ContainerMasterDefinitionId equals ci.ContainerMasterDefinitionId
                                               where t.TurnaroundId == turnaroundId
                                               select cm.ContainerMasterDefinition.CustomerDefinition.CurrentCustomer.FacilityId).FirstOrDefault();

                        if ((primaryFacility == facilityId) || (IsSecondaryFacility(facilityId, repository, primaryFacility)))
                        {
                            turnaround = turnaroundRepository.Get(turnaroundId);
                        }
                    }
                    SetProductValuesWithTurnaroundData(turnaround, result);
                    break;
                case CustomerDefectAssociationType.ContainerMaster:
                    containerMaster = containerMasterRepository.GetContainerMasterUsingExternalIdAndFacility(itemId, facilityId);
                    SetProductValueswithContainerMasterData(result, containerMaster);
                    break;
                case CustomerDefectAssociationType.ContainerMasterAutoId:
                    containerMaster = containerMasterRepository.GetLatestContainerMaster(Convert.ToInt32(itemId));
                    SetProductValueswithContainerMasterData(result, containerMaster);
                    break;
                case CustomerDefectAssociationType.ContainerInstance:
                    try
                    {
                        {
                            var primaryFacility = GetPrimaryFacilityByContainerInstancePrimaryId(itemId, repository);

                            if ((primaryFacility == facilityId) ||
                                (IsSecondaryFacility(facilityId, repository, primaryFacility)))
                            {
                                var inactiveInstance =
                                    containerInstanceRepository.Repository.Find(CustomLinqExpressions.ContainerInstanceHasPrimaryId(itemId))
                                        .FirstOrDefault()
                                        .Archived != null;
                                if (inactiveInstance)
                                {
                                    result.Add(new GenericKeyValue
                                    {
                                        Tag = "ErrorMsgActiveInstance",
                                        Name = "Please enter an active Instance ID."
                                    });
                                }
                                else
                                {
                                    var turnarounds = turnaroundRepository.Repository.Find(CustomLinqExpressions.TurnaroundContainerInstanceHasPrimaryId(itemId));
                                    turnaround = turnarounds.OrderByDescending(i => i.Created).FirstOrDefault();

                                    if (turnaround != null)
                                    {
                                        var maintenanceSetting = maintenanceReportRepository.GetMaintenanceReportSettingByCustomerDefinition(turnaround.DeliveryPoint.CustomerDefinitionId, MaintenanceTypeIdentifier.Repair);

                                        if (maintenanceSetting == Enums.MaintenanceReportSetting.Off)
                                        {
                                            result.Add(new GenericKeyValue
                                            {
                                                Tag = "ErrorMsgRepairsDisabled",
                                                Name = "Repairs are off for this customer."
                                            });
                                        }
                                        else
                                        {
                                            if (maintenanceSetting == Enums.MaintenanceReportSetting.Suspended)
                                            {
                                                result.Add(new GenericKeyValue
                                                {
                                                    Tag = "WarningMsgRepairsSuspended",
                                                    Name = "Warning: repairs are suspended for this customer."
                                                });
                                            }

                                            SetProductValuesWithTurnaroundData(turnaround, result);
                                        }
                                    }
                                    else
                                    {
                                        result.Add(new GenericKeyValue
                                        {
                                            Tag = "ErrorMsgActiveInstanceTurnaround",
                                            Name = "Please enter an Instance ID with an active turnaround."
                                        });
                                    }
                                }
                            }
                            else
                            {
                                result.Add(new GenericKeyValue { Tag = "ErrorMsgActiveInstanceTurnaround", Name = "Please enter an Instance ID with an active turnaround." });
                            }
                        }
                    }
                    catch
                    {
                        result.Add(new GenericKeyValue { Tag = "ErrorMsgValidInstance", Name = "Please enter valid Instance ID." });
                    }
                       
                    break;
                case CustomerDefectAssociationType.ContainerInstanceAutoId:
                    containerInstance = containerInstanceRepository.Get(Convert.ToInt32(itemId));
                    if (containerInstance != null)
                    {
                        {
                            var primaryFacility = GetPrimaryFacilityByContainerInstancePrimaryId(containerInstance.PrimaryId, repository);

                            if ((primaryFacility == facilityId) || (IsSecondaryFacility(facilityId, repository, primaryFacility)))
                            {
                                var turnaroundList = turnaroundRepository.Repository.Find(CustomLinqExpressions.TurnaroundContainerInstanceHasPrimaryId(containerInstance.PrimaryId));
                                turnaround = turnaroundList.OrderByDescending(i => i.Created).FirstOrDefault();
                                SetProductValuesWithTurnaroundData(turnaround, result);
                            }
                        }
                    }
                    break;

            }
            return result;
        }

        private static void SetProductValueswithContainerMasterData(List<IGenericKeyValue> result, IContainerMaster containerMaster)
        {
            if (containerMaster != null)
            {
                result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.Turnaround.ToString(), Name = string.Empty });
                result.Add(new GenericKeyValue { Tag = "ContainerMasterId", Name = containerMaster.ContainerMasterId.ToString() });
                result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.ContainerMaster.ToString(), Name = containerMaster.ExternalId });
                result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.ContainerInstance.ToString(), Name = string.Empty });
                result.Add(new GenericKeyValue { Tag = "CustomerDefinitionID", Name = (containerMaster as ContainerMaster).ContainerMasterDefinition.CustomerDefinitionId.ToString() });
                result.Add(new GenericKeyValue { Tag = "ContainerMasterName", Name = containerMaster.Text });
            }
        }

        private static void SetProductValuesWithTurnaroundData(Turnaround turnaround, List<IGenericKeyValue> result)
        {
            if (turnaround != null)
            {
                result.Add(new GenericKeyValue { Tag = CustomerDefectAssociationType.Turnaround.ToString(), Name = turnaround.ExternalId.ToString() });
                if (turnaround.ContainerMaster != null)
                {
                    var latestContainerMaster = turnaround.ContainerMaster.ContainerMasterDefinition.ContainerMasters.FirstOrDefault(i => i.ItemStatusId == (short)ItemStatusTypeIdentifier.Active);

                    if (latestContainerMaster != null)
                    {
                        result.Add(new GenericKeyValue { Tag = "LatestContainerMasterId", Name = latestContainerMaster.ContainerMasterId.ToString() });
                        result.Add(new GenericKeyValue { Tag = "LatestContainerMasterName", Name = latestContainerMaster.Text });

                    }
                    result.Add(new GenericKeyValue
                    {
                        Tag = CustomerDefectAssociationType.ContainerMaster.ToString(),
                        Name = turnaround.ContainerMaster.ExternalId
                    });
                    result.Add(new GenericKeyValue { Tag = "ContainerMasterId", Name = turnaround.ContainerMasterId.ToString() });
                    result.Add(new GenericKeyValue { Tag = "ContainerMasterName", Name = turnaround.ContainerMaster.Text });

                }
                if (turnaround.ContainerInstance != null)
                {
                    result.Add(new GenericKeyValue
                    {
                        Tag = CustomerDefectAssociationType.ContainerInstance.ToString(),
                        Name = turnaround.ContainerInstance.PrimaryId
                    });
                    result.Add(new GenericKeyValue { Tag = "ContainerInstanceAutoId", Name = turnaround.ContainerInstance.ContainerInstanceId.ToString() });
                }
                else
                {
                    result.Add(new GenericKeyValue { Tag = "ErrorMsg", Name = "Please enter turnaround id which has a valid container instance id." });
                }
                if (turnaround.DeliveryPoint != null)
                {
                    result.Add(new GenericKeyValue
                    {
                        Tag = CustomerDefectAssociationType.DeliveryPoint.ToString(),
                        Name = turnaround.DeliveryPoint.Text
                    });

                    result.Add(new GenericKeyValue
                    {
                        Tag = CustomerDefectAssociationType.Customer.ToString(),
                        Name = turnaround.DeliveryPoint.CustomerDefinition.Customer.OrderByDescending(i => i.Revision).FirstOrDefault().Text
                    });
                }

                result.Add(new GenericKeyValue { Tag = "TurnaroundAutoId", Name = turnaround.TurnaroundId.ToString() });
                result.Add(new GenericKeyValue { Tag = "CustomerDefinitionID", Name = turnaround.DeliveryPoint.CustomerDefinitionId.ToString() });
                result.Add(new GenericKeyValue { Tag = "DeliveryPointID", Name = turnaround.DeliveryPointId.ToString() });
                result.Add(new GenericKeyValue { Tag = "CustomerID", Name = turnaround.DeliveryPoint.CustomerDefinition.Customer.OrderByDescending(i => i.Revision).FirstOrDefault().CustomerId.ToString() });
            }
        }

        private static bool IsSecondaryFacility(int facilityId, PathwayRepository repository, short primaryFacility)
        {
            return repository.Container.MultiFacilityProcessHandShake.
                                   Where(mfph => mfph.RequestingFacilityId == primaryFacility
                                          && mfph.MultiFacilityProcessingId != null).Any(i => i.MultiFacilityProcessing.AlternateProcessingFacilityId == facilityId);
        }

        private static short GetPrimaryFacilityByContainerInstancePrimaryId(string externalId, PathwayRepository repository)
        {
            return repository.Container.ContainerInstance.FirstOrDefault(CustomLinqExpressions.ContainerInstanceHasPrimaryId(externalId)).DeliveryPoint.CustomerDefinition.Customer.OrderByDescending(i => i.CustomerId).FirstOrDefault().FacilityId;
        }
    }
}