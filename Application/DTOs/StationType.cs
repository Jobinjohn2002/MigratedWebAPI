using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class StationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StationTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public StationType()
        {
            this.Station = new HashSet<Station>();
            this.TurnaroundEvent = new HashSet<TurnaroundEvent>();
            this.Stations1 = new HashSet<Station>();
            this.EventTypes = new HashSet<EventType>();
            this.Facilities = new HashSet<Facility>();
            this.EventTypeStationTypes = new HashSet<EventTypeStationType>();
            this.StationTypeItemType = new HashSet<StationTypeItemType>();
            this.PlannedMaintenanceFlagSettings = new HashSet<PlannedMaintenanceFlagSettings>();
            this.ContainerMasterNoteStationType = new HashSet<ContainerMasterNoteStationType>();
            this.TurnaroundNoteStationType = new HashSet<TurnaroundNoteStationType>();
            this.ProcessingNoteStationType = new HashSet<ProcessingNoteStationType>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public byte StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeCategoryId
        /// </summary>
        public byte StationTypeCategoryId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public short DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets AllowAssignPPM
        /// </summary>
        public bool AllowAssignPPM { get; set; }
        /// <summary>
        /// Gets or sets AllowAssignNotes
        /// </summary>
        public bool AllowAssignNotes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual ICollection<Station> Station { get; set; }
        /// <summary>
        /// Gets or sets StationTypeCategory
        /// </summary>
        public virtual StationTypeCategory StationTypeCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual ICollection<TurnaroundEvent> TurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Stations1
        /// </summary>
        public virtual ICollection<Station> Stations1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets EventTypes
        /// </summary>
        public virtual ICollection<EventType> EventTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public virtual ICollection<Facility> Facilities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets EventTypeStationTypes
        /// </summary>
        public virtual ICollection<EventTypeStationType> EventTypeStationTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StationTypeItemType
        /// </summary>
        public virtual ICollection<StationTypeItemType> StationTypeItemType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PlannedMaintenanceFlagSettings
        /// </summary>
        public virtual ICollection<PlannedMaintenanceFlagSettings> PlannedMaintenanceFlagSettings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerMasterNoteStationType
        /// </summary>
        public virtual ICollection<ContainerMasterNoteStationType> ContainerMasterNoteStationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundNoteStationType
        /// </summary>
        public virtual ICollection<TurnaroundNoteStationType> TurnaroundNoteStationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ProcessingNoteStationType
        /// </summary>
        public virtual ICollection<ProcessingNoteStationType> ProcessingNoteStationType { get; set; }
    }
}
