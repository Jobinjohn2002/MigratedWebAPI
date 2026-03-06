using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// EndoscopyDeconTaskScanDetails
    /// </summary>
    public class EndoscopyDeconTaskScanDetails : ScanDetails
    {
        /// <summary>
        /// Gets or sets DeconTaskId
        /// </summary>
        public int DeconTaskId { get; set; }

        public bool? Result { get; set; }

        public int? FailureTypeId { get; set; }

        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets FailureText
        /// </summary>
        public string FailureText { get; set; }
    }

    /// <summary>
    /// EndoscopyDeconTasksData
    /// </summary>
    public class EndoscopyDeconTasksData : SynergyTrakData
    {
        /// <summary>
        /// Gets or sets EndoscopyDeconTaskRequest
        /// </summary>
        public EndoscopyDeconTaskRequest EndoscopyDeconTaskRequest { get; set; }
    }

    /// <summary>
    /// EndoscopyDeconTasks
    /// </summary>
    public class EndoscopyDeconTasks : BaseHelper
    {
        private new EndoscopyDeconTasksData Data => (EndoscopyDeconTasksData)base.Data;

        public EndoscopyDeconTasks(SynergyTrakData data) : base(data) { }

        public EndoscopyDeconTasks(EndoscopyDeconTaskRequest endoscopyDeconTaskRequest) : base(new EndoscopyDeconTasksData()
        {
            EndoscopyDeconTaskRequest = endoscopyDeconTaskRequest,
            StationTypeId = (int)StationTypeIdentifier.EndoscopyHub,
            ProcessNotificationsDlgt = new NotificationEngineHelper().ProcessNotifications
        })
        { }

        /// <summary>
        /// FinishPreAerDeconTasks operation
        /// </summary>
        public ScanAssetDataContract FinishPreAerDeconTasks() => FinishPreAerDeconTasks(Data.EndoscopyDeconTaskRequest);

        private ScanAssetDataContract FinishPreAerDeconTasks(EndoscopyDeconTaskRequest endoscopyDeconTaskRequest)
        {
            ScanAssetDataContract result = new ScanAssetDataContract();

            if (endoscopyDeconTaskRequest.ClientUTCDateTime.Year == 1900)
            {
                return new ScanAssetDataContract() { ErrorCode = (int)ErrorCodes.InvalidRequest };
            }

            var mk3Helper = new SynergyTrakHelperMk3(Data, true);

            foreach (var endoscopyDeconTaskResult in endoscopyDeconTaskRequest.EndoscopyDeconTaskResults)
            {
                if (endoscopyDeconTaskResult.Result.HasValue)
                {
                    var eventToApply = endoscopyDeconTaskResult.Result.Value ? TurnAroundEventTypeIdentifier.PreAerDeconTaskSuccess : TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure;
                    var offsetTimeSpan = DateTime.UtcNow - endoscopyDeconTaskRequest.ClientUTCDateTime;
                    var endoscopyDeconTaskScanDetails = new EndoscopyDeconTaskScanDetails
                    {
                        ApplyToBatch = true,
                        ApplyEvent = true,
                        StationId = endoscopyDeconTaskRequest.StationId,
                        StationTypeId = (int)StationTypeIdentifier.EndoscopyHub,
                        StationLocationId = endoscopyDeconTaskRequest.StationLocationId.Value,
                        FacilityId = endoscopyDeconTaskRequest.FacilityId,
                        UserId = endoscopyDeconTaskRequest.UserId,
                        ParentTurnaroundId = null,
                        IsRemoveFromParent = true,
                        TurnaroundId = endoscopyDeconTaskRequest.TurnaroundId,
                        PinReason= endoscopyDeconTaskRequest.PinReasonId,
                        Events = new List<ScanEventDataContract>
                        {
                            new ScanEventDataContract
                            {
                                EventType = (int)eventToApply
                            }
                        },
                        Created = endoscopyDeconTaskResult.Created.Value.Add(offsetTimeSpan),//throw exception if this is null. it should not be
                        RetrospectiveCreatedDate = endoscopyDeconTaskResult.Created.Value.Add(offsetTimeSpan),
                        DeconTaskId = endoscopyDeconTaskResult.DeconTaskId,
                        Result = endoscopyDeconTaskResult.Result,
                        FailureTypeId = endoscopyDeconTaskResult.FailureTypeId,
                        FailureText = endoscopyDeconTaskResult.FailureText,
                        IsNetworkPrinting = endoscopyDeconTaskRequest.IsNetworkPrinting,
                        LaserPrinter = endoscopyDeconTaskRequest.LaserPrinter,
                        LabelPrinter = endoscopyDeconTaskRequest.LabelPrinter
                    };

                    ScanAssetDataContract taskResult = new ScanAssetDataContract();

                    mk3Helper.Scan(endoscopyDeconTaskScanDetails, taskResult);
                    if (taskResult.ErrorCode != null)
                    {
                        return taskResult;
                    }
                    if (taskResult.Reports != null && taskResult.Reports.Any())
                    {
                        if (result.Reports == null)
                        {
                            result.Reports = new List<ReportDataContract>();
                        }

                        result.Reports.AddRange(taskResult.Reports);
                    }

                    Data.ScanDcList.Clear();
                }
            }
            var deconEndScanDetails = new ScanDetails
            {
                ApplyEvent = true,
                StationId = endoscopyDeconTaskRequest.StationId,
                StationTypeId = (int)StationTypeIdentifier.EndoscopyHub,
                StationLocationId = endoscopyDeconTaskRequest.StationLocationId.Value,
                FacilityId = endoscopyDeconTaskRequest.FacilityId,
                UserId = endoscopyDeconTaskRequest.UserId,
                ParentTurnaroundId = null,
                IsRemoveFromParent = true,
                TurnaroundId = endoscopyDeconTaskRequest.TurnaroundId,
                PinReason = endoscopyDeconTaskRequest.PinReasonId,
                Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.DeconEnd}
                },
                IsNetworkPrinting = endoscopyDeconTaskRequest.IsNetworkPrinting,
                LaserPrinter = endoscopyDeconTaskRequest.LaserPrinter,
                LabelPrinter = endoscopyDeconTaskRequest.LabelPrinter
            };

            var hasFailedDeconTasks = endoscopyDeconTaskRequest.EndoscopyDeconTaskResults.Any(r => r.Result.HasValue && r.Result.Value == false);

            if (hasFailedDeconTasks)
            {
                deconEndScanDetails.Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.DeconCancel },
                };
            }

            mk3Helper.Scan(deconEndScanDetails, result);

            if (hasFailedDeconTasks)
            {
                Data.QuarantineReasonId = (int)QuarantineReasonIdentifier.PreAerTasksFailed;
                var quarantine = new Quarantine(Data);
                quarantine.PutIntoQuarantine(result, deconEndScanDetails, (int)QuarantineReasonIdentifier.PreAerTasksFailed);
            }
            return result;
        }
    }
}