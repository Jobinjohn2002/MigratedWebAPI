using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PlannedMaintenanceFlagSettings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PlannedMaintenanceFlagSettingsFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PlannedMaintenanceFlagSettings()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PlannedMaintenanceFlagSettingsId
        /// </summary>
        public int PlannedMaintenanceFlagSettingsId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public byte StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets PlannedMaintenanceFlags
        /// </summary>
        public short PlannedMaintenanceFlags { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public Nullable<short> EventTypeId { get; set; }
    
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual Facility Facility { get; set; }
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public virtual StationType StationType { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public virtual EventType EventType { get; set; }
    }
}
