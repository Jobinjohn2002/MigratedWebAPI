using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum InvoiceTypeIdentifier
    {
        [EnumMember]
        Customer = 0,
        [EnumMember]
        CustomerGroup = 1,
        [EnumMember]
        Directorate = 2
    }
}
