using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// UserLoginDatacontract
    /// </summary>
    public class UserLoginDatacontract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets UserExternalId
        /// </summary>
        public string UserExternalId { get; set; }
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }
        public int? StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets ApplicationTypeId
        /// </summary>
        public int ApplicationTypeId { get; set; }
    }
}