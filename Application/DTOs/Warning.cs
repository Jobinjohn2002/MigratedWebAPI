using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Warning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use WarningFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Warning()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets WarningId
        /// </summary>
        public int WarningId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public Nullable<int> ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public Nullable<int> ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets MaximumTurnarounds
        /// </summary>
        public Nullable<int> MaximumTurnarounds { get; set; }
        /// <summary>
        /// Gets or sets MaximumDays
        /// </summary>
        public Nullable<int> MaximumDays { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundLeadIn
        /// </summary>
        public Nullable<int> TurnaroundLeadIn { get; set; }
        /// <summary>
        /// Gets or sets WarningOnly
        /// </summary>
        public bool WarningOnly { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets LeadInDays
        /// </summary>
        public Nullable<int> LeadInDays { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public Nullable<int> CreatedUserId { get; set; }
    
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public virtual ItemMaster ItemMaster { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public virtual ContainerMaster ContainerMaster { get; set; }
    }
}
