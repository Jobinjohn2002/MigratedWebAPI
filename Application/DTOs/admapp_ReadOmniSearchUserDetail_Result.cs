using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchUserDetail_Result
    {
        /// <summary>
        /// Gets or sets Userid
        /// </summary>
        public int Userid { get; set; }
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets IsLockedOut
        /// </summary>
        public bool IsLockedOut { get; set; }
        /// <summary>
        /// Gets or sets IsExpired
        /// </summary>
        public bool IsExpired { get; set; }
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
    }
}
