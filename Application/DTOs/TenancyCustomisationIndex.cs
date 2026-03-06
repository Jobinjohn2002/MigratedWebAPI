using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TenancyCustomisationIndex
    /// </summary>
    public class TenancyCustomisationIndex
    {
        public enum ConfirmationMessage
        {
            None = 0,
            CacheSynchronised = 1
        }

        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public ConfirmationMessage Confirmation { get; set; }

        /// <summary>
        /// Gets or sets Tables
        /// </summary>
        public List<CustomisableTable> Tables { get; set; }

        /// <summary>
        /// Gets or sets CustomisableLists
        /// </summary>
        public List<CustomisableList> CustomisableLists { get; set; }
    }
}