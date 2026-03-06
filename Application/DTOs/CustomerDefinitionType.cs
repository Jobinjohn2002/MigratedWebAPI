using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum CustomerDefinitionType
    {
        [EnumMember]
        [Description("Hospital")]
        Hospital = 1,

        [EnumMember]
        [Description("Loan Vendor")]
        LoanVendor = 2,
    }
}