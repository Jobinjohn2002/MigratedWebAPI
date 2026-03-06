using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ScanContainerDataContract
    /// </summary>
    public class ScanContainerDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets IsApplyingEvent
        /// </summary>
        public bool IsApplyingEvent { get; set; }   // Not a datamember though. Just svc side only.
        /// <summary>
        /// Gets or sets ScannedString
        /// </summary>
        public string ScannedString { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
        /// <summary>
        /// Gets or sets Containers
        /// </summary>
        public IList<ContainerDetailsDataContract> Containers { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; } = new DateTime(1900, 1, 1);
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        public int? ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets LastMessage
        /// </summary>
        public string LastMessage { get; set; }
        /// <summary>
        /// Gets or sets Packer
        /// </summary>
        public string Packer { get; set; }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        /// <summary>
        /// Gets or sets LastTurnaroundId
        /// </summary>
        public int LastTurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundLive
        /// </summary>
        public bool IsTurnaroundLive { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets Warnings
        /// </summary>
        public IList<WarningDataContract> Warnings { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNotes
        /// </summary>
        public IList<NoteDataContract> ContainerMasterNotes { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundNotes
        /// </summary>
        public IList<NoteDataContract> TurnaroundNotes { get; set; }
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public IList<DefectDataContract> Defects { get; set; }
        /// <summary>
        /// Gets or sets IsWorkflowSuccessful
        /// </summary>
        public bool IsWorkflowSuccessful { get; set; }
        public int? ParentTurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets IsParentABatchTag
        /// </summary>
        public bool IsParentABatchTag { get; set; }
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvents
        /// </summary>
        public List<TurnaroundEventDataContract> TurnaroundEvents { get; set; }
        public int? LastTurnaroundEventId { get; set; }
        public short? LastProcessEventId { get; set; }
        public int? LastProcessEventWorkflowId { get; set; }
        public int? EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventCreated
        /// </summary>
        public DateTime TurnaroundEventCreated { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPtId
        /// </summary>
        public int DeliveryPtId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPtName
        /// </summary>
        public string DeliveryPtName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets ChildItems
        /// </summary>
        public List<ScanContainerDataContract> ChildItems { get; set; }
        public List<byte[]> ReportData { get; set; }
        /// <summary>
        /// Gets or sets PmWarned
        /// </summary>
        public List<KeyValueDataContract> PmWarned { get; set; }
        /// <summary>
        /// Gets or sets PmQuarantined
        /// </summary>
        public List<KeyValueDataContract> PmQuarantined { get; set; }
    }

    #region Biological Indicator

    #endregion
}
