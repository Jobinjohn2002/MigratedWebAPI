using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ServiceRequirement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ServiceRequirementFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ServiceRequirement()
        {
            this.Turnaround = new HashSet<Turnaround>();
            this.TurnaroundWH = new HashSet<TurnaroundWH>();
            this.ItemTypes = new HashSet<ItemType>();
            this.ServiceRequirementExpiryWindow = new HashSet<ServiceRequirementExpiryWindow>();
            this.InvoiceLine = new HashSet<InvoiceLine>();
            this.ServiceRequirementContractedHours = new HashSet<ServiceRequirementContractedHours>();
            this.ServiceRequirementEventType = new HashSet<ServiceRequirementEventType>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserId
        /// </summary>
        public Nullable<int> ArchivedUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets ExpiryCalculationTypeId
        /// </summary>
        public byte ExpiryCalculationTypeId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementDefinitionId
        /// </summary>
        public int ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public short Revision { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundMinutes
        /// </summary>
        public short TurnaroundMinutes { get; set; }
        /// <summary>
        /// Gets or sets Margin
        /// </summary>
        public double Margin { get; set; }
        /// <summary>
        /// Gets or sets MarginAppliesToReprocessing
        /// </summary>
        public bool MarginAppliesToReprocessing { get; set; }
        /// <summary>
        /// Gets or sets MarginAppliesToSingleUse
        /// </summary>
        public bool MarginAppliesToSingleUse { get; set; }
        /// <summary>
        /// Gets or sets MarginAppliesToOther
        /// </summary>
        public bool MarginAppliesToOther { get; set; }
        /// <summary>
        /// Gets or sets GraceMinutes
        /// </summary>
        public short GraceMinutes { get; set; }
        public System.DateTime Effective { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public Nullable<int> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public Nullable<bool> IsFastTrack { get; set; }
    
        /// <summary>
        /// Gets or sets ExpiryCalculationType
        /// </summary>
        public virtual ExpiryCalculationType ExpiryCalculationType { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementDefinition
        /// </summary>
        public virtual ServiceRequirementDefinition ServiceRequirementDefinition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual ICollection<Turnaround> Turnaround { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundWH
        /// </summary>
        public virtual ICollection<TurnaroundWH> TurnaroundWH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemTypes
        /// </summary>
        public virtual ICollection<ItemType> ItemTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ServiceRequirementExpiryWindow
        /// </summary>
        public virtual ICollection<ServiceRequirementExpiryWindow> ServiceRequirementExpiryWindow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets InvoiceLine
        /// </summary>
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ServiceRequirementContractedHours
        /// </summary>
        public virtual ICollection<ServiceRequirementContractedHours> ServiceRequirementContractedHours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ServiceRequirementEventType
        /// </summary>
        public virtual ICollection<ServiceRequirementEventType> ServiceRequirementEventType { get; set; }
    }
}
