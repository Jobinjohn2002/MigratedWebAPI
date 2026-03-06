using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TransferNote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TransferNoteFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TransferNote()
        {
            this.TransferNoteLine = new HashSet<TransferNoteLine>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TransferNoteId
        /// </summary>
        public int TransferNoteId { get; set; }
        /// <summary>
        /// Gets or sets FromOwnerId
        /// </summary>
        public int FromOwnerId { get; set; }
        /// <summary>
        /// Gets or sets ToOwnerId
        /// </summary>
        public int ToOwnerId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets RouteToEventTypeId
        /// </summary>
        public short RouteToEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets TransportTurnaroundId
        /// </summary>
        public int TransportTurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets DispatchTransferNoteEventId
        /// </summary>
        public Nullable<int> DispatchTransferNoteEventId { get; set; }
        /// <summary>
        /// Gets or sets InboundEventId
        /// </summary>
        public Nullable<int> InboundEventId { get; set; }
        /// <summary>
        /// Gets or sets CancelledEventId
        /// </summary>
        public Nullable<int> CancelledEventId { get; set; }
    
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public virtual EventType EventType { get; set; }
        /// <summary>
        /// Gets or sets Owner
        /// </summary>
        public virtual Owner Owner { get; set; }
        /// <summary>
        /// Gets or sets Owner1
        /// </summary>
        public virtual Owner Owner1 { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual Turnaround Turnaround { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TransferNoteLine
        /// </summary>
        public virtual ICollection<TransferNoteLine> TransferNoteLine { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent1
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent1 { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent2
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent2 { get; set; }
    }
}
