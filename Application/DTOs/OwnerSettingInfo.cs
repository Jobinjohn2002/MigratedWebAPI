using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{

    /// <summary>
    /// OwnerSettingInfo
    /// </summary>
    public class OwnerSettingInfo
    {
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// Gets or sets Facilies
        /// </summary>
        public string Facilies { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public string Customers { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }
}