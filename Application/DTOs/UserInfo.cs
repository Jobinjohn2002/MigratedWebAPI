using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserInfo
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FullName
        /// </summary>
        public string FullName { get; set; }
    }
}
