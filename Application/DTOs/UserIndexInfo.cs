using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserIndexInfo
    /// </summary>
    public class UserIndexInfo
    {
        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public List<UserInfo> Users { get; set; }
    }
}