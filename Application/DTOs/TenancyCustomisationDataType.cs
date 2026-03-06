using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum TenancyCustomisationConfirmation
    {
        None = 0,
        Enabled = 1,
        Updated = 2,
        Disabled = 3
    }

    /// <summary>
    /// Group
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Values
        /// </summary>
        public List<TenancyCustomValue> Values { get; set; } 
    }

    /// <summary>
    /// TenancyCustomisationDataType
    /// </summary>
    public class TenancyCustomisationDataType
    {
        public TenancyCustomisationDataType()
        {
            Groups = new List<Group>();
        }

        /// <summary>
        /// Gets or sets Table
        /// </summary>
        public CustomisableTable Table { get; set; }
        /// <summary>
        /// Gets or sets TenancyTableConfig
        /// </summary>
        public TenancyCustomisableTable TenancyTableConfig { get; set; }
        /// <summary>
        /// Gets or sets Groups
        /// </summary>
        public List<Group> Groups { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public TenancyCustomisationConfirmation Confirmation { get; set; }
    }
}