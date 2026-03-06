using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum PrintContentTypeIdentifier
    {
        [EnumMember]
        SystemPrint = 1,
        [EnumMember]
        TrayList = 2,
        [EnumMember]
        TrayListFrontSheet = 3,
        [EnumMember]
        QALabel = 4,
        [EnumMember]
        DecontaminationCertificate = 5,
        [EnumMember]
        DeliveryNote = 6,
        [EnumMember]
        InboundList = 7,
        [EnumMember]
        IntoQuarantine = 8,
        [EnumMember]
        AuditException = 9,
        [EnumMember]
        AERPassed = 10,
        [EnumMember]
        VacuumPackedWet = 11,
        [EnumMember]
        VacuumPackedDry = 12,
        [EnumMember]
        FacilityTransferOutbound = 13,
        [EnumMember]
        SystemPrintTest = 14,
        [EnumMember]
        IntoAutoclaveBatchReport = 15,
        [EnumMember]
        OutOfAutoclaveBatchReport = 16,
        [EnumMember]
        PackingFailedTraylist = 17,
        [EnumMember]
        OrderManifest = 18,
        [EnumMember]
        TransferNote = 19,
        [EnumMember]
        DirtyInstrumentTraylist = 20,
        [EnumMember]
        WashReleaseDeliveryPointSummary = 21,
        [EnumMember]
        WasherBatchReport = 22,
        [EnumMember]
        WashInBatchReport = 23,
        [EnumMember]
        WashReleaseBatchReport = 24,
        [EnumMember]
        PackList = 25,
        [EnumMember]
        FailedDecontamination = 26,
        [EnumMember]
        OutOfAERPassedLabel = 27,
        [EnumMember]
        RemovedFromDryingCabWetLabel = 28,
        [EnumMember]
        RemovedFromDryingCabDryLabel = 29,
        [EnumMember]
        VacuumPackedWetLabel = 30,
        [EnumMember]
        VacuumPackedDryLabel = 31,
        [EnumMember]
        SystemPrintLabel = 32
    }
}