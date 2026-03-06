using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TransferNoteLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TransferNoteLineFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TransferNoteLine()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TransferNoteLineId
        /// </summary>
        public int TransferNoteLineId { get; set; }
        /// <summary>
        /// Gets or sets TransferNoteId
        /// </summary>
        public int TransferNoteId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets BeforeTransferProcessEventId
        /// </summary>
        public int BeforeTransferProcessEventId { get; set; }
        /// <summary>
        /// Gets or sets AddToTransferNoteEventId
        /// </summary>
        public int AddToTransferNoteEventId { get; set; }
        /// <summary>
        /// Gets or sets DispatchTransferNoteEventId
        /// </summary>
        public Nullable<int> DispatchTransferNoteEventId { get; set; }
        /// <summary>
        /// Gets or sets RemovedFromTransferNoteEventId
        /// </summary>
        public Nullable<int> RemovedFromTransferNoteEventId { get; set; }
        /// <summary>
        /// Gets or sets InboundEventId
        /// </summary>
        public Nullable<int> InboundEventId { get; set; }
    
        /// <summary>
        /// Gets or sets TransferNote
        /// </summary>
        public virtual TransferNote TransferNote { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent1
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent1 { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent2
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent2 { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual Turnaround Turnaround { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent21
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent21 { get; set; }
    }
}
