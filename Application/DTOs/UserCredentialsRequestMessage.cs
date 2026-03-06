using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// UserCredentialsRequestMessage
    /// </summary>
    public class UserCredentialsRequestMessage
    {
        public UserCredentialsRequestMessage(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }
    }
}