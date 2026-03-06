using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Credentials
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Gets or sets AuthID
        /// </summary>
        public string AuthID { get; set; }
        /// <summary>
        /// Gets or sets AuthPwd
        /// </summary>
        public string AuthPwd { get; set; }
    }
}