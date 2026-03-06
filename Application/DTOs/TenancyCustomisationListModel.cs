using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TenancyCustomisationListModel
    /// </summary>
    public class TenancyCustomisationListModel
    {
        /// <summary>
        /// Gets or sets AvailableLists
        /// </summary>
        public List<CustomisableList> AvailableLists { get; set; }
        /// <summary>
        /// Gets or sets ConfigurableList
        /// </summary>
        public ConfigurableListDataContract ConfigurableList { get; set; }
    }
}