using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Customer status types enum
    /// </summary>
    /// <remarks></remarks>
    public enum CostingModelTypeIdentifier
    {
        [EnumMember]
        UserDefined = 1,
        [EnumMember]
        PriceCategoryChoice = 2,
        [EnumMember]
        Manual = 3,
    }
}