using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ContainerMasterTab
    {
        Details = 0,
        Specification = 1
    }

    /// <summary>
    /// ContainerMasterDetailsModel
    /// </summary>
    public class ContainerMasterDetailsModel
    {
        /// <summary>
        /// Gets or sets AdditionalInstancesCount
        /// </summary>
        public int AdditionalInstancesCount { get; set; }
        /// <summary>
        /// Gets or sets MyInstanceCount
        /// </summary>
        public int MyInstanceCount { get; set; }
        /// <summary>
        /// Gets or sets IncludeAllContainerInstances
        /// </summary>
        public bool IncludeAllContainerInstances { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public ContainerMasterTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public ContainerMaster ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets Specification
        /// </summary>
        public List<ContainerMasterSpecification> Specification { get; set; }
        /// <summary>
        /// Gets or sets LatestRevision
        /// </summary>
        public ContainerMaster LatestRevision { get; set; }
        /// <summary>
        /// Gets or sets masterHasImages
        /// </summary>
        public bool masterHasImages { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstances
        /// </summary>
        public TableModel ContainerInstances { get; set; }
        /// <summary>
        /// Gets or sets Aliases
        /// </summary>
        public IDictionary<int, string> Aliases { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public Customer Customer { get; set; }
    }

    /// <summary>
    /// ContainerInstanceSummary
    /// </summary>
    public class ContainerInstanceSummary
    {
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstance ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets LatestTurnaround
        /// </summary>
        public Turnaround LatestTurnaround { get; set; }
        /// <summary>
        /// Gets or sets LatestEvent
        /// </summary>
        public TurnaroundEvent LatestEvent { get; set; }
        /// <summary>
        /// Gets or sets Event
        /// </summary>
        public EventType Event { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public ServiceRequirement ServiceRequirement { get; set; }
    }

    /// <summary>
    /// ContainerMasterSpecification
    /// </summary>
    public class ContainerMasterSpecification
    {
        public ItemMasterDefinition ItemMasterDefinition{ get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public ItemMaster ItemMaster { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentNote
        /// </summary>
        public string ContainerContentNote { get; set; }
    }
}