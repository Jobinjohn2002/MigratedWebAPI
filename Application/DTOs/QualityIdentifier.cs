using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum QualityIdentifier
    {
        [Display(Name = "Not Reviewed")]
        [EnumMember]
        NotReviewed = 1,

        [Display(Name = "Standard")]
        [EnumMember]
        Standard = 2,

        [Display(Name = "High")]
        [EnumMember]
        High = 3,

        [Display(Name = "Reviewed Not Verified")]
        [EnumMember]
        ReviewedNotVerified = 4,

        [Display(Name = "Verified")]
        [EnumMember]
        Verified = 5,

        [Display(Name = "Very High")]
        [EnumMember]
        VeryHigh = 6,
    }
}
