using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LoginModel
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }
        [AllowHtml]
        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets RememberMe
        /// </summary>
        public bool RememberMe { get; set; }
    }
}