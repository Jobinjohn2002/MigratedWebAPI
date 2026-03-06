using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ContainerInstanceTab
    {
        Details = 0,
        Turnarounds = 1,
        Specification = 2
    }

    /// <summary>
    /// ContainerInstanceDetailsModel
    /// </summary>
    public class ContainerInstanceDetailsModel
    {
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public ContainerInstanceTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstance ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public ContainerMaster ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public ItemType ItemType { get; set; }
        /// <summary>
        /// Gets or sets ItemStatus
        /// </summary>
        public ItemStatus ItemStatus { get; set; }
        /// <summary>
        /// Gets or sets OwningCustomer
        /// </summary>
        public Customer OwningCustomer { get; set; }
        /// <summary>
        /// Gets or sets UsingCustomer
        /// </summary>
        public Customer UsingCustomer { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public DeliveryPoint DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public ServiceRequirement ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundHistory
        /// </summary>
        public TableModel TurnaroundHistory { get; set; }
        /// <summary>
        /// Gets or sets TotalTurnarounds
        /// </summary>
        public int TotalTurnarounds { get; set; }
        /// <summary>
        /// Gets or sets ItemComponents
        /// </summary>
        public TableModel ItemComponents { get; set; }
        /// <summary>
        /// Gets or sets instanceHasImages
        /// </summary>
        public bool instanceHasImages { get; set; }
        /// <summary>
        /// Gets or sets masterHasImages
        /// </summary>
        public bool masterHasImages { get; set; }
        /// <summary>
        /// Gets or sets CanQuarantine
        /// </summary>
        public bool CanQuarantine { get; set; }
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public List<Defect> Defects { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefects
        /// </summary>
        public List<CustomerDefect> CustomerDefects { get; set; }
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public List<LoanSet> LoanSets { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReports
        /// </summary>
        public List<MaintenanceReport> MaintenanceReports { get; set; }
        /// <summary>
        /// Gets or sets CurrentTurnaround
        /// </summary>
        public Turnaround CurrentTurnaround { get; set; }
        /// <summary>
        /// Gets or sets CanSearchSimilar
        /// </summary>
        public bool CanSearchSimilar { get; set; }
        /// <summary>
        /// Gets or sets IsIdentifiable
        /// </summary>
        public bool IsIdentifiable { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedures
        /// </summary>
        public List<SurgicalProcedure> SurgicalProcedures { get; set; }

        /// <summary>
        /// Gets or sets DisplayIdentifiable
        /// </summary>
        public bool DisplayIdentifiable { get; set; }
        /// <summary>
        /// Gets or sets HasDeliveryPointAccess
        /// </summary>
        public bool HasDeliveryPointAccess { get; set; }
        /// <summary>
        /// Gets or sets ItemComponentList
        /// </summary>
        public List<ItemComponentModel> ItemComponentList { get; set; }
    }
}