using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryNotePrintDataContract
    /// </summary>
    public class DeliveryNotePrintDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets RequiresProof
        /// </summary>
        public bool RequiresProof { get; set; }
        public byte[] ReportData { get; set; }
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public List<DeliveryNoteTurnaroundDataContract> Turnarounds { get; set; }
        /// <summary>
        /// Gets or sets PrinterName
        /// </summary>
        public string PrinterName { get; set; }
        /// <summary>
        /// Gets or sets IsNetworkPrinting
        /// </summary>
        public bool IsNetworkPrinting { get; set; }
        public string DeliveryNoteExternalId;
        public int? DeliveryNoteId;
        public string OrderNumber;
        /// <summary>
        /// Gets or sets ScannedAsset
        /// </summary>
        public ScanAssetDataContract ScannedAsset { get; set; }
        /// <summary>
        /// Gets or sets NumberOfCopies
        /// </summary>
        public int NumberOfCopies { get; set; } = 1;
    }
}