using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InstrumentCrossMatch
    /// </summary>
    public class InstrumentCrossMatch
    {
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionID
        /// </summary>
        public int ItemMasterDefinitionID { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterID
        /// </summary>
        public int ItemMasterID { get; set; }
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }
        /// <summary>
        /// Gets or sets IsPrimaryMatch
        /// </summary>
        public bool IsPrimaryMatch { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    }
}
