using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class UserClockingEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use UserClockingEventFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public UserClockingEvent()
        {
            this.User2 = new HashSet<User>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets UserClockingEventId
        /// </summary>
        public int UserClockingEventId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        public System.DateTime ClockingTime { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public Nullable<int> StationId { get; set; }
        /// <summary>
        /// Gets or sets LocationPath
        /// </summary>
        public string LocationPath { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets ClockingEventTypeId
        /// </summary>
        public int ClockingEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsAutomatic
        /// </summary>
        public bool IsAutomatic { get; set; }
        /// <summary>
        /// Gets or sets InitiatedFromLocationId
        /// </summary>
        public int InitiatedFromLocationId { get; set; }
        /// <summary>
        /// Gets or sets InitiatedByUserId
        /// </summary>
        public int InitiatedByUserId { get; set; }
        /// <summary>
        /// Gets or sets InitiatedFromStationId
        /// </summary>
        public int InitiatedFromStationId { get; set; }
    
        /// <summary>
        /// Gets or sets ClockingEventType
        /// </summary>
        public virtual ClockingEventType ClockingEventType { get; set; }
        /// <summary>
        /// Gets or sets InitiatedFromLocation
        /// </summary>
        public virtual Location InitiatedFromLocation { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public virtual Location Location { get; set; }
        /// <summary>
        /// Gets or sets InitiatedFromStation
        /// </summary>
        public virtual Station InitiatedFromStation { get; set; }
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual Station Station { get; set; }
        /// <summary>
        /// Gets or sets InitiatedByUser
        /// </summary>
        public virtual User InitiatedByUser { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets User2
        /// </summary>
        public virtual ICollection<User> User2 { get; set; }
    }
}
