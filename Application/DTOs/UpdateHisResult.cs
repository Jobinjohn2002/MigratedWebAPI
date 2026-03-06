using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UpdateHisResult
    /// </summary>
    public class UpdateHisResult
    {
        /// <summary>
        /// Gets or sets HeaderUpdated
        /// </summary>
        public bool HeaderUpdated { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointChangeFailure
        /// </summary>
        public bool DeliveryPointChangeFailure { get; set; }
    }
}
