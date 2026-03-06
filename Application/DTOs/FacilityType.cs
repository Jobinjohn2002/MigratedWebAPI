using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum FacilityType
    {
        [EnumMember]
        [Description("Sterile Processing Department")]
        SPD = 1,

        [EnumMember]
        [Description("Vendor Catalogue")]
        VendorCatalogue = 2,
    }
}