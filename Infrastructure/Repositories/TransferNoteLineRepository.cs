using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class TransferNoteLineRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public TransferNoteLine Get(int transferNoteLineId)
        {
            return Repository.Find(transferNoteLine => transferNoteLine.TransferNoteLineId == transferNoteLineId).FirstOrDefault();
        }

        /// <summary>
        /// IsValidTransferProcess operation
        /// </summary>
        public ValidateTransferResult IsValidTransferProcess(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            var facilityId = scanDetails.FacilityId;
            var itemTypeId = scanDC.Asset.ItemTypeId;
            var isValid = false;
            var hasRestrictions = false;
            var validRestrictions = false;
            var eventTypeId = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).FirstOrDefault(te => te.IsProcessEvent && (TurnAroundEventTypeIdentifier)te.EventTypeId != TurnAroundEventTypeIdentifier.RemoveFromBatchTag)?.EventTypeId;
            if (eventTypeId != null)
            {
                var lastProcessEventTypeId = scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.RemoveFromBatchTag ?
                    (TurnAroundEventTypeIdentifier)eventTypeId 
                    : scanDC.LastProcessEventTypeId;

                using (var repository = new PathwayRepository())
                {
                    if (scanDetails.RouteToEventTypeId == null) return ValidateTransferResult.Invalid;
                    if (scanDetails.DestinationFacilityId == null) return ValidateTransferResult.Invalid;

                    var rules = repository.DataManager.ExecuteQuery((row, table, set) => new
                        {
                            IsValid = Convert.ToBoolean(row["IsValid"]),
                            HasRestrictions = Convert.ToBoolean(row["HasRestrictions"]),
                            ValidRestrictions = Convert.ToBoolean(row["ValidRestrictions"])
                        },
                        "dbo.TransferNote_ValidateTurnaroundRestriction",
                        CommandType.StoredProcedure,
                        new SqlParameter("SendingFacilityId", facilityId),
                        new SqlParameter("RecipientFacilityId", scanDetails.DestinationFacilityId.Value),
                        new SqlParameter("ItemTypeId", itemTypeId),
                        new SqlParameter("FromSenderEventTypeId", lastProcessEventTypeId),
                        new SqlParameter("ToRecipientEventTypeId", scanDetails.RouteToEventTypeId.Value),
                        new SqlParameter("TurnaroundId", scanDC.TurnaroundId.GetValueOrDefault())
                    );

                    if (rules.Any())
                    {
                        isValid = rules.First().IsValid;
                        hasRestrictions = rules.First().HasRestrictions;
                        validRestrictions = rules.First().ValidRestrictions;
                    }
                }
            }

            if (!isValid)
            {
                if (hasRestrictions && !validRestrictions)
                {
                    return ValidateTransferResult.InvalidRestrictions;
                }
                return ValidateTransferResult.InvalidWorkflow;
            }

            return ValidateTransferResult.Valid;
        }
    }
}