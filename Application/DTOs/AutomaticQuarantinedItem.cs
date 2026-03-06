using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AutomaticQuarantinedItem
    /// </summary>
    public class AutomaticQuarantinedItem
    {
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets PrimaryId
        /// </summary>
        public string PrimaryId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefects
        /// </summary>
        public List<CustomerDefectDataContract> CustomerDefects { get; set; }
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public List<DefectDataContract> Defects { get; set; }
    }
}
