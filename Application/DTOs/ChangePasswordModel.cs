using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Do not rename these fellas
    /// </summary>
    public enum ChangePasswordReason
    {
        None = 0,
        NewUser = 1,
        PasswordExpired = 2
    }

    /// <summary>
    /// ChangePasswordModel
    /// </summary>
    public class ChangePasswordModel
    {
        /// <summary>
        /// Gets or sets Reason
        /// </summary>
        public ChangePasswordReason Reason { get; set; }
        [AllowHtml]
        /// <summary>
        /// Gets or sets CurrentPassword
        /// </summary>
        public string CurrentPassword { get; set; }
        [AllowHtml]
        /// <summary>
        /// Gets or sets NewPassword
        /// </summary>
        public string NewPassword { get; set; }
        [AllowHtml]
        /// <summary>
        /// Gets or sets ConfirmNewPassword
        /// </summary>
        public string ConfirmNewPassword { get; set; }
    }
}