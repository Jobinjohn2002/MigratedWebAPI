using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ApplyTurnaroundEventDetails
    /// </summary>
    public class ApplyTurnaroundEventDetails
    {
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public TurnAroundEventTypeIdentifier EventType { get; set; }
        public int? DeliveryNoteId;
        public bool RemoveFromParent;
        public int? ParentTurnaroundId;
        public int? LocationId;
        public int? BatchId;
        public string BatchExternalId;
        public bool IsProcessEvent = true;
        public bool? ItemExceptionsApprovalFlag;
        public bool IsEndTurnaround;
        public bool IsAutomaticEvent;
        public bool CanSetTurnaroundExpiryTime = true;
        public DateTime RetrospectiveCreatedDate = DateTime.MinValue;
        public int? RetrospectiveUserId;
        public int RetrospectiveProcessStationTypeId;
        public int? RetrospectiveStationId;
        public int? RetrospectiveLocationId;
        public int? RetrospectivePinRequestReasonId;
        public byte? FailureTypeId;

        /// <summary>
        /// Gets or sets IsAutomaticCreatedEvent
        /// </summary>
        public bool IsAutomaticCreatedEvent { get; set; }
        /// <summary>
        /// Gets or sets IsAutomaticTriggerEvent
        /// </summary>
        public bool IsAutomaticTriggerEvent { get; set; }
        /// <summary>
        /// Gets or sets UseDeliveryNoteIdFromScanDc
        /// </summary>
        public bool UseDeliveryNoteIdFromScanDc { get; set; }

        public ApplyTurnaroundEventDetails()
        { }

        public ApplyTurnaroundEventDetails(TurnAroundEventTypeIdentifier eventType)
        {
            EventType = eventType;
        }

        /// <summary>
        /// Create operation
        /// </summary>
        public static ApplyTurnaroundEventDetails Create(TurnAroundEventTypeIdentifier eventType, bool removeFromParent)
        {
            return new ApplyTurnaroundEventDetails { EventType = eventType, RemoveFromParent = removeFromParent };
        }

        /// <summary>
        /// Create operation
        /// </summary>
        public static ApplyTurnaroundEventDetails Create(TurnAroundEventTypeIdentifier eventType, int? batchId)
        {
            return new ApplyTurnaroundEventDetails { EventType = eventType, BatchId = batchId };
        }

        /// <summary>
        /// Create operation
        /// </summary>
        public static ApplyTurnaroundEventDetails Create(TurnAroundEventTypeIdentifier eventType)
        {
            return new ApplyTurnaroundEventDetails { EventType = eventType };
        }

        /// <summary>
        /// Copy operation
        /// </summary>
        public static ApplyTurnaroundEventDetails Copy(TurnaroundEventDetail ted)
        {
            return new ApplyTurnaroundEventDetails()
            {
                EventType = ted.ApplyEvent.EventType,
                DeliveryNoteId = ted.ApplyEvent.DeliveryNoteId,
                RemoveFromParent = ted.ApplyEvent.RemoveFromParent,
                ParentTurnaroundId = ted.ApplyEvent.ParentTurnaroundId,
                LocationId = ted.ApplyEvent.LocationId,
                BatchId = ted.ApplyEvent.BatchId,
                BatchExternalId = ted.ApplyEvent.BatchExternalId,
                IsProcessEvent = ted.ApplyEvent.IsProcessEvent,
                ItemExceptionsApprovalFlag = ted.ApplyEvent.ItemExceptionsApprovalFlag,
                IsEndTurnaround = ted.ApplyEvent.IsEndTurnaround,
                IsAutomaticEvent = true,
                CanSetTurnaroundExpiryTime = ted.ApplyEvent.CanSetTurnaroundExpiryTime,
                RetrospectiveCreatedDate = ted.ApplyEvent.RetrospectiveCreatedDate,
                RetrospectiveUserId = ted.ApplyEvent.RetrospectiveUserId,
                RetrospectiveProcessStationTypeId = ted.ApplyEvent.RetrospectiveProcessStationTypeId,
                RetrospectiveStationId = ted.ApplyEvent.RetrospectiveStationId,
                RetrospectiveLocationId = ted.ApplyEvent.RetrospectiveLocationId,
                RetrospectivePinRequestReasonId = ted.ApplyEvent.RetrospectivePinRequestReasonId,
                FailureTypeId = ted.ApplyEvent.FailureTypeId
            };
        }
    }

}