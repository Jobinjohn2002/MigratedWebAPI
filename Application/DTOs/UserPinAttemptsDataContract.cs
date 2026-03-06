using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserPinAttemptsDataContract
    /// </summary>
    public class UserPinAttemptsDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets PinAttempts
        /// </summary>
        public int PinAttempts { get; set; }
    }
}