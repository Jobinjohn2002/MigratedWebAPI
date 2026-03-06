using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ProcessingNoteStationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ProcessingNoteStationTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ProcessingNoteStationType()
        {
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
        /// Gets or sets StationTypeId
        /// </summary>
        public byte StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public Nullable<short> EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNoteStationTypeId
        /// </summary>
        public int ProcessingNoteStationTypeId { get; set; }
    
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public virtual EventType EventType { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNote
        /// </summary>
        public virtual ProcessingNote ProcessingNote { get; set; }
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public virtual StationType StationType { get; set; }
    }
}
