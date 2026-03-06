using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserCultureData
    /// </summary>
    public class UserCultureData
    {
        /// <summary>
        /// Gets or sets Application
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets LanguageSet
        /// </summary>
        public string LanguageSet { get; set; }

    }
}
