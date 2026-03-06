using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
   public enum SCSearchType
    {
       
        /// <summary>
        /// Customer search type
        /// </summary>
        [EnumMember]
        Instrument = 1,
        /// <summary>
        /// Items search type
        /// </summary>
        [EnumMember]
        Items = 2,
        /// <summary>
        /// Instances search type
        /// </summary>
        [EnumMember]
        Instances = 3,
        /// <summary>
        /// Turnarounds search type
        /// </summary>
        [EnumMember]
        Turnarounds = 4,
        /// <summary>
        /// DeliveryNotes search type
        /// </summary>
        [EnumMember]
        DeliveryNotes = 5,
        /// <summary>
        /// Defects search type
        /// </summary>
        [EnumMember]
        Defects = 6,
        /// <summary>
        /// LoanSets search type
        /// </summary>
        [EnumMember]
        LoanSets = 7
        
    }
}
