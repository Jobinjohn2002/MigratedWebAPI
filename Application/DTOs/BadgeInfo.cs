using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BadgeInfo
    /// </summary>
    public class BadgeInfo
    {
        /// <summary>
        /// Gets or sets FullName
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets Barcode
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }
    }
}
