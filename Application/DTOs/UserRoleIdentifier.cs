using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum UserRoleIdentifier
    {
        [EnumMember]
        AdminUser = 998,
        [EnumMember]
        FinanceUser = 999,
        [EnumMember]
        SynergyCustomerUser = 1000,
        [EnumMember]
        Administrator = 1001,
        [EnumMember]
        FinanceInvoicer = 1003,
        [EnumMember]
        FinanceRegionalManager = 1004,
        [EnumMember]
        FinanceSeniorManager = 1005,
        [EnumMember]
        AdminAdministrator = 1006,
        [EnumMember]
        FinanceAdministrator = 1007,
        [EnumMember]
        SynergyCustomerAdministrator = 1008,
        [EnumMember]
        ReportingUser = 1010,
        [EnumMember]
        ReportingAdministrator = 1011,
        [EnumMember]
        SynergyCustomerDriver = 1012,
        [EnumMember]
        SynergyCustomerPorter = 1013,
        [EnumMember]
        SynergyCustomerStockManager = 1014,
        [EnumMember]
        SynergyCustomerStandardUser = 1015,
        [EnumMember]
        SynergyCustomerAdvancedUser = 1016,
        [EnumMember]
        FinanceViewer = 1017,
        [EnumMember]
        FinanceRegionalAccountant = 1018,
        [EnumMember]
        OperativeUser = 1022,
        [EnumMember]
        OperativeAdvancedUser = 1023,
        [EnumMember]
        AdminSupervisor = 1024,
        [EnumMember]
        AdminManager = 1025,
        [EnumMember]
        OperativeAdministrator = 1028,
        [EnumMember]
        FinanceSalesLedger = 1042,
        [EnumMember]
        FinanceSeniorFinance = 1043,
        [EnumMember]
        OperativePackingReviewer = 1047
    }
}