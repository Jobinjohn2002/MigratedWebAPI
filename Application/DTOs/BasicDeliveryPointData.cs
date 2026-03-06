using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BasicDeliveryPointData
    /// </summary>
    public class BasicDeliveryPointData
    {
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Selected
        /// </summary>
        public bool Selected { get; set; }
    }
}
