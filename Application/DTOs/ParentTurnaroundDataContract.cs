using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ParentTurnaroundDataContract
    /// </summary>
    public class ParentTurnaroundDataContract
    {
        public int? InstanceId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets CreatedTime
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Gets or sets ChildTurnarounds
        /// </summary>
        public List<ChildTurnaroundDataContract> ChildTurnarounds { get; set; }
        /// <summary>
        /// Gets or sets ChildCount
        /// </summary>
        public int ChildCount { get; set; }
        public int? ChildrenItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public byte MachineTypeId { get; set; }
    }
}