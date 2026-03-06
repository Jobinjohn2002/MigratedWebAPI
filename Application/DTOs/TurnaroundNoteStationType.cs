using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TurnaroundNoteStationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TurnaroundNoteStationTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TurnaroundNoteStationType()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundNoteId
        /// </summary>
        public int TurnaroundNoteId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public byte StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public Nullable<short> EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundNoteStationTypeId
        /// </summary>
        public int TurnaroundNoteStationTypeId { get; set; }
    
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public virtual EventType EventType { get; set; }
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public virtual StationType StationType { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundNote
        /// </summary>
        public virtual TurnaroundNote TurnaroundNote { get; set; }
    }
}
