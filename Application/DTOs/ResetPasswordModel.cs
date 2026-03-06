using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ResetPasswordModel
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets PassPhrase
        /// </summary>
        public string PassPhrase { get; set; }
        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets Auth
        /// </summary>
        public string Auth { get; set; }
        /// <summary>
        /// Gets or sets NewPassword
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// Gets or sets ConfirmNewPassword
        /// </summary>
        public string ConfirmNewPassword { get; set; }
    }
}