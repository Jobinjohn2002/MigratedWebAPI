using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Values that represent customer costing model types.
    /// </summary>
    /// <remarks>Dan.maunder, 02/10/2011.</remarks>
    public enum CustomerCostingModelTypeIdentifier
    {
        [EnumMember]
        UserDefined = 1,

        [EnumMember]
        PriceCategoryChoice = 2,
        
        [EnumMember]
        Manual = 3,
    }
}
