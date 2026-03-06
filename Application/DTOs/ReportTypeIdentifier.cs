using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ReportTypeIdentifier
    {
        [EnumMember]
        DeliveryNote = 0,
        [EnumMember]
        TrayList = 1,
        [EnumMember]
        PackList = 2,
        [EnumMember]
        TrolleyList = 3,
        [EnumMember]
        TurnaroundDetails = 4,
        [EnumMember]
        DecontaminationCertificate = 5,
        [EnumMember]
        CustomerDefect = 6,
        [EnumMember]
        ComponentList = 7,
        [EnumMember]
        ContainerInstanceTrayList = 8,
        [EnumMember]
        SignOffSheet = 9,
        [EnumMember]
        TrayListFrontSheet = 10,
        [EnumMember]
        ServiceReportAuditDetails = 11,
        [EnumMember]
        TrayListMaster = 12,
        [EnumMember]
        PackListSterile_SL = 13,
        [EnumMember]
        PackListNonSterile_SL = 14,
        [EnumMember]
        ContainerNote_SL = 15,
        [EnumMember]
        DisposableOrderNote_SL = 16,
        [EnumMember]
        MaintenanceReportDetail = 17,
        [EnumMember]
        DailyTestReport = 18,
        [EnumMember]
        WeeklyTestReport = 19,
        [EnumMember]
        InstrumentStock = 20,
        [EnumMember]
        OrderPickList = 21,
        [EnumMember]
        OrderInvoice = 22,
        [EnumMember]
        ServiceReport = 23,
        [EnumMember]
        ProductionReport = 24,
        [EnumMember]
        SingleUseComponents = 25,
        [EnumMember]
        ItemsForCustomer = 26,
        [EnumMember]
        ItemInstanceList = 27,
        [EnumMember]
        TrayList_SupervisorNotAvailable = 28,
        [EnumMember]
        TurnaroundsForBatch = 29,
        [EnumMember]
        MaintenanceReportList = 30,

    }
}