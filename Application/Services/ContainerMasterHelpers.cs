using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ContainerMasterHelper
    {
        /// <summary>
        /// GetContainerMasterDetails operation
        /// </summary>
        public static void GetContainerMasterDetails(ScanAssetDataContract scanDC)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var deliveryPointRepository = DeliveryPointRepository.New(workUnit);

                var containerMaster = containerMasterRepository.Get(scanDC.Asset.ContainerMasterId);

                if (containerMaster != null)
                {
                    scanDC.Asset.ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId;
                    scanDC.Asset.ContainerMasterName = containerMaster.Text;
                    scanDC.Asset.ContainerMasterId = containerMaster.ContainerMasterId;
                    scanDC.Asset.ContainerMasterExternalId = containerMaster.ExternalId;
                    scanDC.Asset.MachineTypeId = containerMaster.MachineTypeId;
                    scanDC.Asset.ItemTypeId = containerMaster.ItemTypeId;
                    scanDC.Asset.ItemTypeText = containerMaster.ItemType.Text;
                    scanDC.Asset.BaseItemTypeId = containerMaster.ItemType.ParentItemTypeId == null
                        ? containerMaster.ItemTypeId
                        : containerMaster.ItemType.ParentItemTypeId.Value;
                    scanDC.Asset.TrackIndividualInstruments = containerMaster.TrackIndividualInstruments;

                    scanDC.SpecialityId = containerMaster.SpecialityId;
                    scanDC.ComplexityId = containerMaster.ComplexityId;
                    scanDC.IndependentQaCheck = containerMaster.IndependentQualityAssuranceCheck;

                    var itemTypeRepository = ItemTypeRepository.New(workUnit);
                    var itemTypeRow = itemTypeRepository.Get(scanDC.Asset.ItemTypeId);

                    scanDC.Asset.IsNonSterile = ((itemTypeRow != null) && (itemTypeRow.IsNonSterileProduct));
                    scanDC.Asset.ContainerMasterDeliveryPoints = deliveryPointRepository.ReadSelectedDeliveryPointForContainerMaster(containerMaster.ContainerMasterDefinitionId, false, containerMaster.ContainerMasterDefinition.CustomerDefinitionId);

                    if (scanDC.Asset.ContainerInstanceId.HasValue)
                    {
                        var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                        var containerInstance = containerInstanceRepository.Get(scanDC.Asset.ContainerInstanceId.Value);
                        var audit = containerInstance.ContainerInstanceLabelAudit.OrderByDescending(x => x.Created).FirstOrDefault()?.Created;
                        if (audit != null)
                        {
                            scanDC.Asset.LastLabelPrinted = DateTime.SpecifyKind(audit.Value, DateTimeKind.Utc);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// GetContainerMasterDetailsByExternalId operation
        /// </summary>
        public static void GetContainerMasterDetailsByExternalId(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            {
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var customerRepository = CustomerRepository.New(workUnit);

                var containerMaster = containerMasterRepository.GetContainerMasterByExternalId(scanDetails.ExternalId);

                if (containerMaster != null)
                {
                    scanDC.Asset.ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId;
                    scanDC.Asset.ContainerMasterName = containerMaster.Text;
                    scanDC.Asset.ContainerMasterId = containerMaster.ContainerMasterId;
                    scanDC.Asset.ContainerMasterExternalId = containerMaster.ExternalId;
                    scanDC.Asset.ItemTypeId = containerMaster.ItemTypeId;
                    scanDC.Asset.ItemTypeText = containerMaster.ItemType.Text;
                    scanDC.DeliveryPtId = containerMaster.DeliveryPointIds.FirstOrDefault();
                    scanDC.Asset.BaseItemTypeId = containerMaster.ItemType.ParentItemTypeId == null
                        ? containerMaster.ItemTypeId
                        : containerMaster.ItemType.ParentItemTypeId.Value;
                    var customer = customerRepository.ReadCustomerByItem(containerMaster.ContainerMasterId);
                    if (customer != null)
                    {
                        scanDC.Asset.CustomerName = customer.Text;
                    }
                    scanDC.Asset.ContainerMasterDeliveryPoints = containerMaster.DeliveryPoints.Where(c => c.CustomerDefinitionId == containerMaster.ContainerMasterDefinition.CustomerDefinitionId && c.Archived == null).Select(d =>
                    {
                        var customers = d.CustomerDefinition.Customer.Where(c => c.CustomerDefinitionId == d.CustomerDefinitionId).OrderByDescending(o => o.Revision).FirstOrDefault();
                        return customers != null ? new DeliveryPointDataContract
                        {
                            Id = d.DeliveryPointId,
                            Name = d.Text,
                            CustomerDefinitionId = d.CustomerDefinitionId,
                            CustomerName = customers.Text
                        } : null;
                    }).ToList();
                    GetListOfServiceRequirements(workUnit, containerMaster.DeliveryPoints, scanDC);
                }
            }
        }

        /// <summary>
        /// GetContainerMasterAssetDetail operation
        /// </summary>
        public static void GetContainerMasterAssetDetail(ContainerMaster containerMaster, ScanAssetDataContract scanDC)
        {
            scanDC.Asset = new AssetDetailsDataContract
            {
                ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId,
                ContainerMasterName = containerMaster.Text,
                ContainerMasterId = containerMaster.ContainerMasterId,
                ContainerMasterExternalId = containerMaster.ExternalId,
                IsContainerMasterArchived = containerMaster.Archived.HasValue,
                ItemTypeId = containerMaster.ItemTypeId,
                ItemTypeText = containerMaster.ItemType.Text,
                BaseItemTypeId = containerMaster.ItemType.ParentItemTypeId == null ? containerMaster.ItemTypeId : containerMaster.ItemType.ParentItemTypeId.Value,
                TrackIndividualInstruments = containerMaster.TrackIndividualInstruments,
            };
        }

        /// <summary>
        /// GetListOfServiceRequirements operation
        /// </summary>
        public static void GetListOfServiceRequirements(IUnitOfWork workUnit, IEnumerable<DeliveryPoint> deliveryPoints, ScanAssetDataContract scanDC)
        {
            var serviceRequirementRepository = ServiceRequirementRepository.New(workUnit);

            var customerIds = deliveryPoints.Select(i => i.CustomerDefinitionId).Distinct().ToList();
            scanDC.Asset.ServiceRequirements = new List<ServiceRequirementDataContract>();

            foreach (var customerDefinitionId in customerIds)
            {
                var serviceRequirements = serviceRequirementRepository.GetAllServiceRequirementsBySRDefinitionByCustomerAndItemType(customerDefinitionId, scanDC.Asset.ItemTypeId);
                scanDC.Asset.ServiceRequirements.AddRange(serviceRequirements.Select(s => new ServiceRequirementDataContract
                {
                    Id = s.ServiceRequirementId,
                    Name = s.Text,
                    CustomerDefinitionId = customerDefinitionId
                }).ToList());
            }
        }

        /// <summary>
        /// CreateContainerMasterPrice operation
        /// </summary>
        public static void CreateContainerMasterPrice(int containerMasterId, IUnitOfWork workUnit)
        {
            var containerMasterRepository = new ContainerMasterRepository(workUnit);
            var containerMaster = containerMasterRepository.Get(containerMasterId);
            if (!containerMaster.ContainerMasterPrices.Any())
            {
                using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
                {
                    repository.DataManager.ExecuteNonQuery("dbo.finapp_CreateContainerMasterPrice", CommandType.StoredProcedure,
                        new SqlParameter
                        {
                            ParameterName = "@ContainerMasterId",
                            Value = containerMasterId,
                            SqlDbType = SqlDbType.Int
                        });
                }
            }
        }
    }
}