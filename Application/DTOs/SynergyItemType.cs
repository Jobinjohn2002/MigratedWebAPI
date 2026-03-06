using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum SynergyItemType
    {
        [EnumMember]
        DeliveryPoint,

        [EnumMember]
        Customer,

        [EnumMember]
        CustomerGroup,

        [EnumMember]
        CustomerDefects,

        [EnumMember]
        FastTrack,

        [EnumMember]
        OverdueItem,

        [EnumMember]
        Facility,

        [EnumMember]
        Station,

        [EnumMember]
        Item,

        [EnumMember]
        Container,

        [EnumMember]
        Instance,

        [EnumMember]
        Turnarounds,

        [EnumMember]
        Defects,

        [EnumMember]
        User,

        [EnumMember]
        Production,

        [EnumMember]
        Machine,

        [EnumMember]
        Home,

        [EnumMember]
        Report,

        [EnumMember]
        ComponentStock,

        [EnumMember]
        Overview,

        [EnumMember]
        Order,

        [EnumMember]
        Enquiry,

        [EnumMember]
        EnquiryDetails,

        [EnumMember]
        ViewOpenOrder,

        [EnumMember]
        OrderSummary,

        [EnumMember]
        OrderDetails,

        [EnumMember]
        OrderFulfillment,

        [EnumMember]
        Pigeonhole,

        [EnumMember]
        Condemn,

        [EnumMember]
        LoanSetRecord,

        [EnumMember]
        ItemInstance,

        [EnumMember]
        MaintenanceReport,

        [EnumMember]
        SterilisationTestReport,

        [EnumMember]
        Vendor,

        [EnumMember]
        Batches,

        [EnumMember]
        StockLocation,

        [EnumMember]
        Quality,

        [EnumMember]
        Location,

        [EnumMember]
        Tree,

        [EnumMember]
        OrderTemplate,

        [EnumMember]
        ClockingOverview,

        [EnumMember]
        FeedbackCentre,

        [EnumMember]
        SITAudit,

    }
}