using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ChangePasswordDataContract
    /// </summary>
    public class ChangePasswordDataContract
    {
        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public ChangePasswordResult Result { get; set; }
        /// <summary>
        /// Gets or sets UnusablePrevoiusPasswords
        /// </summary>
        public int UnusablePrevoiusPasswords { get; set; }
    }
}
