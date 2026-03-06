using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfigurableListValueDataContract
    /// </summary>
    public class ConfigurableListValueDataContract
    {
        /// <summary>
        /// Gets or sets ConfigurableListValueId
        /// </summary>
        public int ConfigurableListValueId { get; set; }
        public int? CustomValueId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Gets or sets IsSelected
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Gets or sets IsSystem
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// Gets or sets ParentText
        /// </summary>
        public string ParentText { get; set; }
        public bool? BatchCycleIsChargeable { get; set; }
    }
}