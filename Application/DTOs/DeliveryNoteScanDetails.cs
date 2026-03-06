using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryNoteScanDetails
    /// </summary>
    public class DeliveryNoteScanDetails : ScanDetails
    {
        public int? DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyExternalId
        /// </summary>
        public string TrolleyExternalId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyContainerInstanceId
        /// </summary>
        public int TrolleyContainerInstanceId { get; set; }

        /// <summary>
        /// CopyClass operation
        /// </summary>
        public DeliveryNoteScanDetails CopyClass()
        {
            return new DeliveryNoteScanDetails
            {
                DeliveryNoteId = this.DeliveryNoteId,
                TrolleyExternalId = this.TrolleyExternalId,
                TurnaroundExternalId = base.TurnaroundExternalId,
                TurnaroundId = base.TurnaroundId,
                InstanceId = base.InstanceId,
                ExternalId = base.ExternalId,
                BaseItemTypeId = base.BaseItemTypeId,
                StationTypeId = base.StationTypeId,
                StationId = base.StationId,
                Events = base.Events,
                ParentTurnaroundId = base.ParentTurnaroundId,
                ParentItemTypeId = base.ParentItemTypeId,
                Data = base.Data,
                StringData = base.StringData,
                Count = base.Count,
                PinReason = base.PinReason,
                IgnoreNotesWarningsAndDecon = base.IgnoreNotesWarningsAndDecon,
                BatchId = base.BatchId,
                MachineTypeId = base.MachineTypeId,
                IsRemoveFromParent = base.IsRemoveFromParent,
                ApprovedByUserId = base.ApprovedByUserId,
                ApprovedByUserPinReasonId = base.ApprovedByUserPinReasonId,
                IsServerPrinting = base.IsServerPrinting,
                LaserPrinter = base.LaserPrinter,
                IsNetworkPrinting = base.IsNetworkPrinting,
                FacilityId = base.FacilityId,
                PrimaryFacilityId = base.PrimaryFacilityId
            };
        }
        /// <summary>
        /// Gets or sets ForcePrint
        /// </summary>
        public bool ForcePrint { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets BypassTrolleyDispatch
        /// </summary>
        public bool BypassTrolleyDispatch { get; set; }
    }
    /// <summary>
    /// DeliveryNoteBatchScanDetails
    /// </summary>
    public class DeliveryNoteBatchScanDetails : ScanDetails
    {
        /// <summary>
        /// Gets or sets TrolleyContainerInstanceIds
        /// </summary>
        public List<int> TrolleyContainerInstanceIds { get; set; }
    }
}