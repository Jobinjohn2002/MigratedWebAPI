using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class CustomerSettings
    {
        /// <summary>
        /// GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint operation
        /// </summary>
        public static bool GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint(Order order, IUnitOfWork workUnit)
        {
            return GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint(order.DeliveryPoint.CustomerDefinitionId, order.DeliveryPoint.CustomerDefinition.CurrentCustomer.FacilityId, order.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Owner.TenancyId, workUnit);
        }

        /// <summary>
        /// GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint operation
        /// </summary>
        public static bool GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint(int customerDefinitionId, short facilityId, int tenancyId, IUnitOfWork workUnit)
        {
            var customerSettingRepository = CustomerSettingRepository.New(workUnit);
            var customerSetting = customerSettingRepository.ReadCustomerSetting<bool?>(customerDefinitionId, KnownCustomerSetting.ForceOrderToMatchTurnaroundDeliveryPoint);
            if (customerSetting != null)
            {
                return customerSetting.Value;
            }

            var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
            var facilitySetting = facilitySettingRepository.ReadFacilitySetting<bool?>(facilityId, KnownFacilitySetting.ForceOrderToMatchTurnaroundDeliveryPoint);
            if (facilitySetting != null)
            {
                return facilitySetting.Value;
            }

            var tenancySettingRepository = TenancySettingRepository.New(workUnit);
            var tenancySetting = tenancySettingRepository.ReadTenancySetting<bool?>(tenancyId, KnownTenancySetting.ForceOrderToMatchTurnaroundDeliveryPoint);
            if (tenancySetting != null)
            {
                return tenancySetting.Value;
            }

            return false;
        }

        /// <summary>
        /// GetEvaluatedCultureForCustomer operation
        /// </summary>
        public static string GetEvaluatedCultureForCustomer(int customerDefinitionId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var customerSettingRepository = CustomerSettingRepository.New(workUnit);
                var customerSetting = customerSettingRepository.ReadCustomerSetting<string>(customerDefinitionId, KnownCustomerSetting.PreferredCulture);
                if (customerSetting != null)
                {
                    return customerSetting;
                }

                var customerRepo = CustomerRepository.New(workUnit);
                var latestCustomer = customerRepo.GetActiveOneByDefinitionId(customerDefinitionId);

                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                var facilitySetting = facilitySettingRepository.ReadFacilitySetting<string>(latestCustomer.FacilityId, KnownFacilitySetting.PreferredCulture);
                if (facilitySetting != null)
                {
                    return facilitySetting;
                }

                var customerDefRepo = CustomerDefinitionRepository.New(workUnit);
                var customerDefintion = customerDefRepo.Get(customerDefinitionId);

                var ownerRepo = OwnerRepository.New(workUnit);
                var owner = ownerRepo.Get(customerDefintion.OwnerId);

                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<string>(owner.TenancyId, KnownTenancySetting.PreferredCulture);
                if (tenancySetting != null)
                {
                    return tenancySetting;
                }

                return GetCultureForSystem(workUnit);
            }
        }

        /// <summary>
        /// GetEvaluatedCultureForCustomer operation
        /// </summary>
        public static string GetEvaluatedCultureForCustomer(int customerDefinitionId, short facilityId)
        {
            {
                var customerSettingRepository = CustomerSettingRepository.New(workUnit);
                var customerSetting = customerSettingRepository.ReadCustomerSetting<string>(customerDefinitionId, KnownCustomerSetting.PreferredCulture);

                if (customerSetting != null)
                {
                    return customerSetting;
                }

                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                var facilitySetting = facilitySettingRepository.ReadFacilitySetting<string>(facilityId, KnownFacilitySetting.PreferredCulture);

                if (facilitySetting != null)
                {
                    return facilitySetting;
                }

                var customerDefRepo = CustomerDefinitionRepository.New(workUnit);
                var customerDefintion = customerDefRepo.Get(customerDefinitionId);

                var ownerRepo = OwnerRepository.New(workUnit);
                var owner = ownerRepo.Get(customerDefintion.OwnerId);

                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<string>(owner.TenancyId, KnownTenancySetting.PreferredCulture);

                if (tenancySetting != null)
                {
                    return tenancySetting;
                }

                return GetCultureForSystem(workUnit);

            }
        }

        public static string PortalSiteCulture
        {
            get
            {
                {
                    var systemSettingRepository = SystemSettingRepository.New(workUnit);
                    var portalSite = systemSettingRepository.GetSetting(KnownSystemSetting.PortalSite).Value;
                    switch (portalSite)
                    {
                        case "Portal_US":
                            return "en-us";
                        case "Portal_UK":
                            return "en-gb";
                        default:
                            return null;
                    }
                }
            }
        }

        private static string GetCultureForSystem(IUnitOfWork workUnit)
        {
            var systemSettingRepository = SystemSettingRepository.New(workUnit);
            var portalSite = systemSettingRepository.GetSetting(KnownSystemSetting.PortalSite);

            if (portalSite.Value == "Portal_US")
            {
                return "en-US";
            }

            return "en-GB";
        }

        public static bool? GetEndoscopyContainerInstanceCaching(int customerDefinitionId)
        {
            {
                return CustomerSettingRepository.New(workUnit)
                    .ReadCustomerSetting<bool?>(customerDefinitionId, KnownCustomerSetting.EndoscopyContainerInstanceCaching);
            }
        }

        /// <summary>
        /// GetEndoscopyCachingCustomers operation
        /// </summary>
        public static List<int> GetEndoscopyCachingCustomers()
        {
            {
                var allsettings = CustomerSettingRepository.New(workUnit)
                    .Get(KnownCustomerSetting.EndoscopyContainerInstanceCaching);

                TypeConverter conv = TypeDescriptor.GetConverter(typeof(bool?));
                bool getValue(string value) { try { return (bool?)conv.ConvertFrom(value) == true; } catch { return false; } }
                
                return (from setting in allsettings
                        where getValue(setting.Value)
                        select setting.CustomerDefinitionId).ToList();
            }
        }

        /// <summary>
        /// GetStockTransferCustomerGroupEnabled operation
        /// </summary>
        public static bool GetStockTransferCustomerGroupEnabled(int customerDefinitionId, bool defaultValue)
        {
            {
                return CustomerSettingRepository.New(workUnit)
                    .ReadCustomerSetting<bool?>(customerDefinitionId, KnownCustomerSetting.EPODStockTransferCustomerGroupEnabled) ?? defaultValue;
            }
        }

    }
}
