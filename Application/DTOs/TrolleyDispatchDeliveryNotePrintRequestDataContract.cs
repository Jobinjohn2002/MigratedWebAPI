using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyDispatchDeliveryNotePrintRequestDataContract
    /// </summary>
    public class TrolleyDispatchDeliveryNotePrintRequestDataContract : ScanDetails
    {
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public List<DeliveryNoteScanDetails> DeliveryNotes { get; set; }
        /// <summary>
        /// Gets or sets TrolleyExternalId
        /// </summary>
        public string TrolleyExternalId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyContainerInstanceId
        /// </summary>
        public int TrolleyContainerInstanceId { get; set; }
    }
}
