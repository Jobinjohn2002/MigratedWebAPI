using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class OwnerMaintenanceReportSettingRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public OwnerMaintenanceReportSetting Get(int ownerMaintenanceReportSettingId)
        {
            return Repository.Find(ownerMaintenanceReportSetting => ownerMaintenanceReportSetting.OwnerMaintenanceReportSettingId == ownerMaintenanceReportSettingId).FirstOrDefault();
        }

        public Enums.MaintenanceReportSetting GetMaintenanceReportSetting(int ownerId, MaintenanceTypeIdentifier? type)
        {
            Enums.MaintenanceReportSetting? customerSetting = null;

            if (type.HasValue)
            {
                customerSetting = GetMaintenanceReportSetting(ownerId, null);
                if (customerSetting == Enums.MaintenanceReportSetting.Off)
                {
                    return customerSetting.Value;
                }
            }

            var setting = Repository.Find(m => m.OwnerId == ownerId &&
                (m.MaintenanceTypeId == (int?)type || (m.MaintenanceTypeId == null && type == null))).FirstOrDefault();

            if (setting == null) 
            {
                return Enums.MaintenanceReportSetting.Off; 
            }
            
            var result = (Enums.MaintenanceReportSetting)setting.MaintenanceReportSettingId;
            if (customerSetting.HasValue && customerSetting == Enums.MaintenanceReportSetting.Suspended && result == Enums.MaintenanceReportSetting.On)
            {
                return customerSetting.Value;
            }

            return result;
        }

        public Enums.MaintenanceReportSetting GetMaintenanceReportSettingByCustomerDefinition(int custDefIdId, MaintenanceTypeIdentifier? type)
        {
            Enums.MaintenanceReportSetting? customerSetting = null;

            if (type.HasValue)
            {
                customerSetting = GetMaintenanceReportSettingByCustomerDefinition(custDefIdId, null);
                if (customerSetting == Enums.MaintenanceReportSetting.Off)
                {
                    return customerSetting.Value;
                }
            }

            var setting = Repository.Find(o => o.Owner.CustomerDefinition.Any(c => c.CustomerDefinitionId == custDefIdId) &&
                            (o.MaintenanceTypeId == (int?)type || (o.MaintenanceTypeId == null && type == null))).FirstOrDefault();

            if (setting == null)
            {
                return Enums.MaintenanceReportSetting.Off;
            }

            var result = (Enums.MaintenanceReportSetting)setting.MaintenanceReportSettingId;
            if (customerSetting.HasValue && customerSetting == Enums.MaintenanceReportSetting.Suspended && result == Enums.MaintenanceReportSetting.On)
            {
                return customerSetting.Value;
            }

            return result;
        }

        public Enums.MaintenanceReportSetting GetMaintenanceReportSettingByTurnaround(int turnaroundId, MaintenanceTypeIdentifier? type)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepo = TurnaroundRepository.New(workUnit);

                var customerDefId = turnaroundRepo.Get(turnaroundId).DeliveryPoint.CustomerDefinitionId;

                return GetMaintenanceReportSettingByCustomerDefinition(customerDefId, type);
            }
        }

        public Enums.MaintenanceReportSetting GetMaintenanceReportSettingByContainerInstance(int containerInstanceId, MaintenanceTypeIdentifier? type)
        {
            {
                var containerInstanceRepo = ContainerInstanceRepository.New(workUnit);

                var custDefId = containerInstanceRepo.Get(containerInstanceId).ContainerMasterDefinition.CustomerDefinitionId;

                return GetMaintenanceReportSettingByCustomerDefinition(custDefId, type);
            }
        }
    }
}