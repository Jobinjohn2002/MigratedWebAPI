using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class Charges
    {
        /// <summary>
        /// RecordCharges operation
        /// </summary>
        public static void RecordCharges(ScanDetails scanDetails)
        {
            var printEvent = scanDetails.Events.FirstOrDefault();

            if (printEvent != null && printEvent.IsChargeable)
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var containerInstanceRep = ContainerInstanceRepository.New(workUnit);
                    var containerInstance = containerInstanceRep.Get(scanDetails.InstanceId.Value);
                    var chargelist = containerInstanceRep.GetPrintBarcodeCharges(scanDetails.InstanceId.Value);
                    var charge = chargelist?.Charge ?? 0M;

                    CreateChargesforPrintingInstances(containerInstance, scanDetails.UserId, charge, containerInstance.DeliveryPoint.CustomerDefinitionId, workUnit);

                    workUnit.Save();
                }
            }
        }

        private static void CreateChargesforPrintingInstances(IContainerInstance instance, int userId, decimal charge, int customerdefinitionId, IUnitOfWork workUnit)
        {
            var chargeDataAdapter = DataAdapterFactory.GetChargeDataAdapter(workUnit);

            chargeDataAdapter.CreateCharge(ChargeFactory.CreateEntity(workUnit,
                chargeListCategoryId: (byte)ChargeListCategoryIdentifier.BarcodeReplacement,
                created: DateTime.UtcNow,
                createdUserId: userId,
                containerInstanceId: instance.ContainerInstanceId,
                deliveryPointId: instance.DeliveryPointId,
                value: charge,
                customerDefinitionId: customerdefinitionId
            ));
        }
    }
}