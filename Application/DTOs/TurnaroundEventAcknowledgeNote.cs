using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TurnaroundEventAcknowledgeNote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TurnaroundEventAcknowledgeNoteFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TurnaroundEventAcknowledgeNote()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundEventId
        /// </summary>
        public int TurnaroundEventId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNoteId
        /// </summary>
        public Nullable<int> ContainerMasterNoteId { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNoteId
        /// </summary>
        public Nullable<int> ProcessingNoteId { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public Nullable<int> StationId { get; set; }
    
        /// <summary>
        /// Gets or sets ContainerMasterNote
        /// </summary>
        public virtual ContainerMasterNote ContainerMasterNote { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNote
        /// </summary>
        public virtual ProcessingNote ProcessingNote { get; set; }
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual Station Station { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent { get; set; }
    }
}
