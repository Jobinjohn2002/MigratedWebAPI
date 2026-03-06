using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BasicCustomerData
    /// </summary>
    public class BasicCustomerData
    {
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public IList<BasicDeliveryPointData> DeliveryPoints { get; set; }
    }
}
