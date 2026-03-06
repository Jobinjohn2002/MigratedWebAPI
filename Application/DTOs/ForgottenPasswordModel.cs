using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ForgottenPasswordModel
    /// </summary>
    public class ForgottenPasswordModel
    {
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets PassPhrase
        /// </summary>
        public string PassPhrase { get; set; }
    }
}