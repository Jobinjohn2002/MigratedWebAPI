using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class StoredProcedureNames
    {
        public const string TrolleyDispatch_GetTrolleyContents = "TrolleyDispatch_GetTrolleyContents";
        public const string TrolleyDispatch_GetTrolleyHubSummary = "TrolleyDispatch_GetTrolleyHubSummary";
        public const string TrolleyDispatch_AssignContentsToDeliveryNote = "TrolleyDispatch_AssignContentsToDeliveryNote";
        public const string TrolleyDispatch_GetTrolleySummary = "TrolleyDispatch_GetTrolleySummary";
        public const string TrolleyDispatch_MFPTurnaroundsForTrolley = "TrolleyDispatch_MFPTurnaroundsForTrolley";
        public const string TrolleyDispatch_GetSuggestedTurnarounds = "TrolleyDispatch_GetSuggestedTurnarounds";

        public const string DeliveryNotes_LoadDeliveryNotesListByFacility = "DeliveryNotes_LoadDeliveryNoteListByFacility";

        public const string Workflow_GetAllPossibleWorkflow = "Workflow_GetAllPossibleWorkflow";

        public const string VendorMaintenance_GetMaintenanceActivityInfoForVendor = "VendorMaintenance_GetMaintenanceActivityInfoForVendor";
        public const string VendorMaintenance_RemoveMaintenanceActivityForVendorAndContracts = "VendorMaintenance_RemoveMaintenanceActivityForVendorAndContracts";
        public const string VendorMaintenance_GetAllContractsForVendor = "VendorMaintenance_GetAllContractsForVendor";

    }
}
