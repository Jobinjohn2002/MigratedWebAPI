using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MaintenanceRulesDropDownList
    /// </summary>
    public class MaintenanceRulesDropDownList
    {
        /// <summary>
        /// Gets or sets CustomerList
        /// </summary>
        public IList<KeyValuePair<int, string>> CustomerList { get; set; }
        /// <summary>
        /// Gets or sets ActivityList
        /// </summary>
        public IList<GenericKeyValueData> ActivityList { get; set; }
        /// <summary>
        /// Gets or sets VendorList
        /// </summary>
        public IList<GenericKeyValueData> VendorList { get; set; }
        /// <summary>
        /// Gets or sets ItemList
        /// </summary>
        public IList<KeyValuePair<string, string>> ItemList { get; set; }
         /// <summary>
         /// Gets or sets CustomerName
         /// </summary>
         public string CustomerName { get; set; }
    }
}
