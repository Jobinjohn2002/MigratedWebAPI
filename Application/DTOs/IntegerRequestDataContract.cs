using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IntegerRequestDataContract
    /// </summary>
    public class IntegerRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Data
        /// </summary>
        public int Data { get; set; }
        
    }
}