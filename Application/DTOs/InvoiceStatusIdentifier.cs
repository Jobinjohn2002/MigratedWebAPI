using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum InvoiceStatusIdentifier
    {
        [EnumMember]
        Finalised = 1,
        [EnumMember]
        UnderReview = 2,
        [EnumMember]
        Provisional = 3,
        [EnumMember]
        AwaitingApproval = 4,
        [EnumMember]
        Approved = 5,
        [EnumMember]
        OnHold = 6,
        [EnumMember]
        NotInvoiced = 7,
        [EnumMember]
        Archived = 8,
        [EnumMember]
        Superseded = 9,
    }
}
