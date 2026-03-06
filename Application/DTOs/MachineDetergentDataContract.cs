using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MachineDetergentDataContract
    /// </summary>
    public class MachineDetergentDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets MachineDetergentId
        /// </summary>
        public int MachineDetergentId { get; set; }
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets ValidFrom
        /// </summary>
        public DateTime ValidFrom { get; set; }
        /// <summary>
        /// Gets or sets DetergentInformation
        /// </summary>
        public string DetergentInformation { get; set; }
        /// <summary>
        /// Gets or sets BatchInformation
        /// </summary>
        public string BatchInformation { get; set; }
    }
}
