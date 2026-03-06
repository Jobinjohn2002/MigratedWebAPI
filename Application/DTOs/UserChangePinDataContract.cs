using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserChangePinDataContract
    /// </summary>
    public class UserChangePinDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Pin
        /// </summary>
        public string Pin { get; set; }
    }
}