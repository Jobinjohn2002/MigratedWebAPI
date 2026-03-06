using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AutoLoginModel
    /// </summary>
    public class AutoLoginModel
    {
        /// <summary>
        /// Gets or sets UserID
        /// </summary>
        public int UserID { get; set; }
        
        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }
    }
}