using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TurnaroundWH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TurnaroundWHFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TurnaroundWH()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundWHId
        /// </summary>
        public int TurnaroundWHId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemTypeId
        /// </summary>
        public short ContainerMasterBaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemType
        /// </summary>
        public string ContainerMasterBaseItemType { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterItemTypeId
        /// </summary>
        public short ContainerMasterItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterItemType
        /// </summary>
        public string ContainerMasterItemType { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public Nullable<int> ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public Nullable<int> DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteExternalId
        /// </summary>
        public Nullable<int> DeliveryNoteExternalId { get; set; }
        public Nullable<System.DateTime> StartEventTime { get; set; }
        /// <summary>
        /// Gets or sets LastEventId
        /// </summary>
        public Nullable<int> LastEventId { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public Nullable<short> LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets LastEventName
        /// </summary>
        public string LastEventName { get; set; }
        public Nullable<System.DateTime> LastEventTime { get; set; }
        /// <summary>
        /// Gets or sets NextEventTypeId
        /// </summary>
        public Nullable<short> NextEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets NextEventName
        /// </summary>
        public string NextEventName { get; set; }
        public System.DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public Nullable<int> BatchId { get; set; }
        /// <summary>
        /// Gets or sets BatchExternalId
        /// </summary>
        public string BatchExternalId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets ParentTurnaroundId
        /// </summary>
        public Nullable<int> ParentTurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets HasChildren
        /// </summary>
        public Nullable<bool> HasChildren { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        public Nullable<System.DateTime> SterileExpiryDate { get; set; }
    
        /// <summary>
        /// Gets or sets ContainerMasterDefinition
        /// </summary>
        public virtual ContainerMasterDefinition ContainerMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNote
        /// </summary>
        public virtual DeliveryNote DeliveryNote { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public virtual DeliveryPoint DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets LastEventType
        /// </summary>
        public virtual EventType LastEventType { get; set; }
        /// <summary>
        /// Gets or sets NextEventType
        /// </summary>
        public virtual EventType NextEventType { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual ItemType ItemType { get; set; }
        /// <summary>
        /// Gets or sets ItemType1
        /// </summary>
        public virtual ItemType ItemType1 { get; set; }
        /// <summary>
        /// Gets or sets ItemType2
        /// </summary>
        public virtual ItemType ItemType2 { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public virtual ServiceRequirement ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual Turnaround Turnaround { get; set; }
        /// <summary>
        /// Gets or sets Turnaround1
        /// </summary>
        public virtual Turnaround Turnaround1 { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual Facility Facility { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public virtual ContainerInstance ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public virtual ContainerMaster ContainerMaster { get; set; }
    }
}
