using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Loan Set Status Types enum
    /// </summary>
    /// <remarks></remarks>
    public enum LoanSetStatusTypeIdentifier
    {
        [EnumMember]
        [Description("New")]
        ForApproval = 1,

        [EnumMember]
        [Description("Synergy Approved")]
        Approved = 2,

        [EnumMember]
        [Description("Loan Set Received")]
        LoanSetReceived = 3,

        [EnumMember]
        [Description("Customer Approved")]
        ApprovedSuitableForUse = 4,

        [EnumMember]
        [Description("Cancelled")]
        Cancelled = 5,

        [EnumMember]
        [Description("Archived")]
        Archived = 6
    }
}