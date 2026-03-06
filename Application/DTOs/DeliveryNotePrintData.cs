using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// DeliveryNotePrintData
    /// </summary>
    public class DeliveryNotePrintData : StationDataBase
    {
        /// <summary>
        /// Gets or sets IsSuccessful
        /// </summary>
        public bool IsSuccessful { get; set; }
    }
}
