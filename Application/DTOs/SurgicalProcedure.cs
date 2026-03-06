using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SurgicalProcedure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SurgicalProcedureFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SurgicalProcedure()
        {
            this.SurgicalProcedureTurnaround = new HashSet<SurgicalProcedureTurnaround>();
            this.Orders = new HashSet<Order>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SurgicalProcedureId
        /// </summary>
        public int SurgicalProcedureId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets SurgeonId
        /// </summary>
        public Nullable<int> SurgeonId { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureTypeId
        /// </summary>
        public Nullable<int> SurgicalProcedureTypeId { get; set; }
        /// <summary>
        /// Gets or sets CaseReference
        /// </summary>
        public string CaseReference { get; set; }
        /// <summary>
        /// Gets or sets PatientReference
        /// </summary>
        public string PatientReference { get; set; }
        public Nullable<System.DateTime> ScheduledOn { get; set; }
        /// <summary>
        /// Gets or sets Duration
        /// </summary>
        public Nullable<int> Duration { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets ModifiedByUserId
        /// </summary>
        public Nullable<int> ModifiedByUserId { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        /// <summary>
        /// Gets or sets AdditionalInstrumentsUsed
        /// </summary>
        public bool AdditionalInstrumentsUsed { get; set; }
        /// <summary>
        /// Gets or sets ArchivedByUserId
        /// </summary>
        public Nullable<int> ArchivedByUserId { get; set; }
        public Nullable<System.DateTime> ArchivedOn { get; set; }
        /// <summary>
        /// Gets or sets RequestedOnBehalfOf
        /// </summary>
        public string RequestedOnBehalfOf { get; set; }
    
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public virtual Location Location { get; set; }
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public virtual Surgeon Surgeon { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureType
        /// </summary>
        public virtual SurgicalProcedureType SurgicalProcedureType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedureTurnaround
        /// </summary>
        public virtual ICollection<SurgicalProcedureTurnaround> SurgicalProcedureTurnaround { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        /// <summary>
        /// Gets or sets User2
        /// </summary>
        public virtual User User2 { get; set; }
    }
}
