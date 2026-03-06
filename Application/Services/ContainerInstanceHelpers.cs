using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs.ContainerInstanceIdentifiers;
using SynergyApplicationFrameworkApi.Application.Services.Shared.ContainerInstanceIdentifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {

        /// <summary>
        /// CreateAssetDataContract operation
        /// </summary>
        public AssetDetailsDataContract CreateAssetDataContract(ContainerInstance containerInstance, List<IItemInstance> itemInstances, IUnitOfWork workUnit)
        {
            AssetDetailsDataContract dc = null;

            if (containerInstance != null)
            {
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var containerMaster = containerMasterRepository.GetActiveOneByContainerMasterDefinitionId(containerInstance.ContainerMasterDefinitionId);

                if (containerMaster != null)
                {
                    dc = new AssetDetailsDataContract
                    {
                        ContainerInstanceId = containerInstance.ContainerInstanceId,
                        ContainerInstancePrimaryId = containerInstance.PrimaryId,
                        ContainerInstanceCreated = containerInstance.Created,
                        TurnaroundWarningCount = containerInstance.TurnaroundWarningCount,
                        ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId,
                        ContainerMasterName = containerMaster.Text,
                        ContainerMasterId = containerMaster.ContainerMasterId,
                        ContainerMasterExternalId = containerMaster.ExternalId,
                        IsContainerMasterArchived = containerMaster.Archived.HasValue,
                        IsContainerInstanceArchived = containerInstance.Archived.HasValue,
                        ItemTypeId = containerMaster.ItemTypeId,
                        ItemTypeText = containerMaster.ItemType.Text,
                        BaseItemTypeId = containerMaster.ItemType.ParentItemTypeId ?? containerMaster.ItemTypeId,
                        TrackIndividualInstruments = containerMaster.TrackIndividualInstruments,
                        MachineTypeId = containerMaster.MachineTypeId,
                        Linear1DBarcodeId = containerInstance.Linear1dBarcodeId,
                        Datamatrix2DBarcodeId = containerInstance.Datamatrix2dBarcodeId,
                        FacilityId = containerInstance.FacilityId,
                        HasIdentifiedItems = (itemInstances != null && itemInstances.Count > 0),
                        IsIdentifiable = containerInstance.IsIdentifiable,
                        CustomerDefinitionId = containerMaster.ContainerMasterDefinition.CustomerDefinitionId,
                        ContainerInstanceIdentifiers = IdentifierConverter.ConvertEntitiesToDataContracts(containerInstance.ContainerInstanceIdentifier.ToList()),
                        Quality = (QualityIdentifier?)containerMaster.ContainerMasterDefinition.Quality?.QualityId,
                        QualityType = (QualityTypeIdentifier?)containerMaster.ContainerMasterDefinition.Quality?.QualityTypeId
                    };

                    dc.ContainerMasterProcessingBatchCycles = GetBatchCycles(containerMaster.ProcessingBatchCycles.ToList());
                }
                else
                {
                    containerMaster = containerMasterRepository.AllByContainerMasterDefinitionId(containerInstance.ContainerMasterDefinitionId).FirstOrDefault();

                    if (containerMaster != null)
                    {
                        dc = new AssetDetailsDataContract
                        {
                            ContainerInstanceId = containerInstance.ContainerInstanceId,
                            ContainerInstancePrimaryId = containerInstance.PrimaryId,
                            ContainerInstanceCreated = containerInstance.Created,
                            TurnaroundWarningCount = containerInstance.TurnaroundWarningCount,
                            ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId,
                            ContainerMasterName = containerMaster.Text,
                            ContainerMasterId = containerMaster.ContainerMasterId,
                            ContainerMasterExternalId = containerMaster.ExternalId,
                            IsContainerMasterArchived = containerMaster.Archived.HasValue,
                            IsContainerInstanceArchived = containerInstance.Archived.HasValue,
                            ItemTypeId = containerMaster.ItemTypeId,
                            ItemTypeText = containerMaster.ItemType.Text,
                            BaseItemTypeId = containerMaster.ItemType.ParentItemTypeId ?? containerMaster.ItemTypeId,
                            TrackIndividualInstruments = containerMaster.TrackIndividualInstruments,
                            MachineTypeId = containerMaster.MachineTypeId,
                            Linear1DBarcodeId = containerInstance.Linear1dBarcodeId,
                            Datamatrix2DBarcodeId = containerInstance.Datamatrix2dBarcodeId,
                            FacilityId = containerInstance.FacilityId,
                            CustomerDefinitionId = containerMaster.ContainerMasterDefinition.CustomerDefinitionId,
                            IsIdentifiable = containerInstance.IsIdentifiable,
                            HasIdentifiedItems = (itemInstances != null && itemInstances.Count > 0),
                                    ContainerInstanceIdentifiers = IdentifierConverter.ConvertEntitiesToDataContracts(containerInstance.ContainerInstanceIdentifier.ToList())
                        };
                    }
                }

                if (dc != null)
                {
                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    var deliveryPoint = deliveryPointRepository.Get(containerInstance.DeliveryPointId);

                    if (deliveryPoint != null)
                    {
                        var customerRepository = CustomerRepository.New(workUnit);
                        var customer = customerRepository.GetActiveOneByDefinitionId(deliveryPoint.CustomerDefinitionId);

                        if (customer != null)
                        {
                            dc.CustomerName = customer.Text;
                        }

                        dc.ContainerInstanceDeliveryPoint = new DeliveryPointDataContract()
                        {
                            Id = deliveryPoint.DeliveryPointId,
                            Name = deliveryPoint.Text,
                            IsStockLocation = deliveryPoint.StockLocation,
                            CustomerDefinitionId = deliveryPoint.CustomerDefinitionId
                        };
                    }

                    var itemTypeRepository = ItemTypeRepository.New(workUnit);
                    var itemTypeRow = itemTypeRepository.Get(dc.ItemTypeId);
                    dc.ContainerAuditRules = new List<AuditRuleContract>();
                    var containerRules = containerMaster.ValidContainerMasterDefinitionAuditRules;

                    foreach (var rule in containerRules)
                    {
                        dc.ContainerAuditRules.Add(new AuditRuleContract()
                        {
                            AuditType = (AuditTypeIdentifier)rule.AuditRule.AuditTypeId,
                            AuditStationCategoryRequirement = (StationTypeCategoryIdentifier)rule.AuditRule.StationTypeCategoryId,
                            IsEnabled = rule.AuditRule.IsEnabled
                        });
                    }

                    dc.IsNonSterile = ((itemTypeRow != null) && (itemTypeRow.IsNonSterileProduct));
                }
            }

            return dc;
        }

        #region private methods

        private BatchCyclesDataContract GetBatchCycles(List<BatchCycle> batchCycles)
        {
            return new BatchCyclesDataContract()
            {
                BatchCycles = batchCycles.Select(
                    bcdc => new BatchCycleDataContract()
                    {
                        CycleTypeId = bcdc.BatchCycleId,
                        Name = bcdc.Text,
                        IsChargeable = bcdc.IsChargeable
                    }
                    ).ToList()
            };
        }

        #endregion
    }
}