using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public abstract class ExtendedError
    {
        /// <summary>
        /// Gets or sets ExtendedErrorMessage
        /// </summary>
        public string ExtendedErrorMessage { get; set; }
    }
}
