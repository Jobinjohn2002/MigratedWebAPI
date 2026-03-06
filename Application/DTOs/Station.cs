using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Station
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StationFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Station()
        {
            this.MachineEvent = new HashSet<MachineEvent>();
            this.StationPrinter = new HashSet<StationPrinter>();
            this.TurnaroundEvent = new HashSet<TurnaroundEvent>();
            this.StationTypes = new HashSet<StationType>();
            this.StationDeliveryPoints = new HashSet<DeliveryPoint>();
            this.Machine = new HashSet<Machine>();
            this.ClientSettings = new HashSet<ClientSettings>();
            this.DeniedTurnaroundEvent = new HashSet<DeniedTurnaroundEvent>();
            this.FailedScan = new HashSet<FailedScan>();
            this.UserClockingEvent = new HashSet<UserClockingEvent>();
            this.UserClockingEvent1 = new HashSet<UserClockingEvent>();
            this.ContainerInstanceLabelAudit = new HashSet<ContainerInstanceLabelAudit>();
            this.SingleInstrumentAudit = new HashSet<SingleInstrumentAudit>();
            this.TurnaroundEventAcknowledgeNote = new HashSet<TurnaroundEventAcknowledgeNote>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserId
        /// </summary>
        public Nullable<int> ArchivedUserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public byte StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets NTLogon
        /// </summary>
        public string NTLogon { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets ShowDirectoratesAtDispatch
        /// </summary>
        public bool ShowDirectoratesAtDispatch { get; set; }
        /// <summary>
        /// Gets or sets ShowReleaseBatches
        /// </summary>
        public bool ShowReleaseBatches { get; set; }
        /// <summary>
        /// Gets or sets ShowPrioritisation
        /// </summary>
        public bool ShowPrioritisation { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public Nullable<int> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets PinRequestReasonId
        /// </summary>
        public Nullable<int> PinRequestReasonId { get; set; }
        /// <summary>
        /// Gets or sets PerformanceDial
        /// </summary>
        public bool PerformanceDial { get; set; }
        /// <summary>
        /// Gets or sets CountdownTimer
        /// </summary>
        public bool CountdownTimer { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public Nullable<int> LocationId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MachineEvent
        /// </summary>
        public virtual ICollection<MachineEvent> MachineEvent { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StationPrinter
        /// </summary>
        public virtual ICollection<StationPrinter> StationPrinter { get; set; }
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public virtual StationType StationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual ICollection<TurnaroundEvent> TurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual Facility Facility { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StationTypes
        /// </summary>
        public virtual ICollection<StationType> StationTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StationDeliveryPoints
        /// </summary>
        public virtual ICollection<DeliveryPoint> StationDeliveryPoints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Machine
        /// </summary>
        public virtual ICollection<Machine> Machine { get; set; }
        /// <summary>
        /// Gets or sets PinRequestReason
        /// </summary>
        public virtual PinRequestReason PinRequestReason { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ClientSettings
        /// </summary>
        public virtual ICollection<ClientSettings> ClientSettings { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets DeniedTurnaroundEvent
        /// </summary>
        public virtual ICollection<DeniedTurnaroundEvent> DeniedTurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FailedScan
        /// </summary>
        public virtual ICollection<FailedScan> FailedScan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserClockingEvent
        /// </summary>
        public virtual ICollection<UserClockingEvent> UserClockingEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserClockingEvent1
        /// </summary>
        public virtual ICollection<UserClockingEvent> UserClockingEvent1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstanceLabelAudit
        /// </summary>
        public virtual ICollection<ContainerInstanceLabelAudit> ContainerInstanceLabelAudit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SingleInstrumentAudit
        /// </summary>
        public virtual ICollection<SingleInstrumentAudit> SingleInstrumentAudit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEventAcknowledgeNote
        /// </summary>
        public virtual ICollection<TurnaroundEventAcknowledgeNote> TurnaroundEventAcknowledgeNote { get; set; }
    }
}
