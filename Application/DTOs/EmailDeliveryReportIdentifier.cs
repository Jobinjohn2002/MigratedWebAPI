using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum EmailDeliveryReportIdentifier
    {
       [EnumMember]
       Success,
       [EnumMember]
       Failed,
       [EnumMember]
       MaxSizeExceeded,
       [EnumMember]
       SMTPError,
       [EnumMember]
       UnKnownError,
    }
}
