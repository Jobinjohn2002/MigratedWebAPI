using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ProcessingNote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ProcessingNoteFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ProcessingNote()
        {
            this.ProcessingNoteStationType = new HashSet<ProcessingNoteStationType>();
            this.ProcessingNote1 = new HashSet<ProcessingNote>();
            this.TurnaroundEventAcknowledgeNote = new HashSet<TurnaroundEventAcknowledgeNote>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ProcessingNoteId
        /// </summary>
        public int ProcessingNoteId { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNoteTypeId
        /// </summary>
        public byte ProcessingNoteTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public Nullable<int> ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        public Nullable<System.DateTime> Expiry { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public Nullable<int> ItemMasterId { get; set; }
        public System.DateTime ActiveFrom { get; set; }
        /// <summary>
        /// Gets or sets PreviousNoteId
        /// </summary>
        public Nullable<int> PreviousNoteId { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public int CreatedBy { get; set; }
    
        /// <summary>
        /// Gets or sets ContainerMasterDefinition
        /// </summary>
        public virtual ContainerMasterDefinition ContainerMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNoteType
        /// </summary>
        public virtual ProcessingNoteType ProcessingNoteType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ProcessingNoteStationType
        /// </summary>
        public virtual ICollection<ProcessingNoteStationType> ProcessingNoteStationType { get; set; }
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public virtual ItemMaster ItemMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ProcessingNote1
        /// </summary>
        public virtual ICollection<ProcessingNote> ProcessingNote1 { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNote2
        /// </summary>
        public virtual ProcessingNote ProcessingNote2 { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUser
        /// </summary>
        public virtual User CreatedByUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEventAcknowledgeNote
        /// </summary>
        public virtual ICollection<TurnaroundEventAcknowledgeNote> TurnaroundEventAcknowledgeNote { get; set; }
    }
}
