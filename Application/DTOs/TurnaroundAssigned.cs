using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TurnaroundAssigned
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TurnaroundAssignedFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TurnaroundAssigned()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundAssignedId
        /// </summary>
        public int TurnaroundAssignedId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundParentId
        /// </summary>
        public int TurnaroundParentId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundChildId
        /// </summary>
        public int TurnaroundChildId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets ChildTurnaround
        /// </summary>
        public virtual Turnaround ChildTurnaround { get; set; }
        /// <summary>
        /// Gets or sets ParentTurnaround
        /// </summary>
        public virtual Turnaround ParentTurnaround { get; set; }
    }
}
