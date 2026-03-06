using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Container for passing SynergyTrakHelperMk3 variables to functionality broken up into other classes.
    /// </summary>
    /// <summary>
    /// SynergyTrakData
    /// </summary>
    public class SynergyTrakData
    {
        /// <summary>
        /// Gets or sets ScanDC
        /// </summary>
        public ScanAssetDataContract ScanDC { get; set; }

        /// <summary>
        /// Gets or sets ScanDetails
        /// </summary>
        public ScanDetails ScanDetails { get; set; }

        /// <summary>
        /// Gets or sets ProcessNotificationsDlgt
        /// </summary>
        public ProcessNotificationsDlgt ProcessNotificationsDlgt { get; set; }

        /// <summary>
        /// Gets or sets KeepBatchTagTogetherRequested
        /// </summary>
        public bool KeepBatchTagTogetherRequested { get; set; }

        /// <summary>
        /// Gets or sets RequiresProof
        /// </summary>
        public bool RequiresProof { get; set; }

        /// <summary>
        /// Gets or sets IntoPidgeonHoleStockExtras
        /// </summary>
        public bool IntoPidgeonHoleStockExtras { get; set; }

        public int? StationLocationId { get; set; }

        public int? StoragePointLocationId { get; set; }

        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public TurnAroundEventTypeIdentifier EventTypeId { get; set; }

        /// <summary>
        /// Gets or sets IsRemoveFromParent
        /// </summary>
        public bool IsRemoveFromParent { get; set; }

        /// <summary>
        /// Gets or sets ScanDcList
        /// </summary>
        public List<ScanAssetDataContract> ScanDcList { get; set; } = new List<ScanAssetDataContract>();

        public short? QuarantineReasonId { get; set; }

        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }

        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        public int? StationId { get; set; }

        public byte? FailureTypeId { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Instance
        /// </summary>
        public SynergyTrakHelperMk3 Instance { get; set; }

        /// <summary>
        /// Gets or sets CanApplyEvent
        /// </summary>
        public bool CanApplyEvent { get; set; } = true;
    }
}