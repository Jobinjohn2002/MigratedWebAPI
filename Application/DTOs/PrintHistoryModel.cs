using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PrintHistoryModel
    /// </summary>
    public class PrintHistoryModel
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets ContentType
        /// </summary>
        public PrintContentTypeIdentifier ContentType { get; set; }
        /// <summary>
        /// Gets or sets ContentRemoved
        /// </summary>
        public bool ContentRemoved { get; set; }
        /// <summary>
        /// Gets or sets Content
        /// </summary>
        public List<PrintHistoryContentModel> Content { get; set; }
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public List<PrintHistoryTurnaroundModel> Turnarounds { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvents
        /// </summary>
        public List<PrintHistoryTurnaroundEventModel> TurnaroundEvents { get; set; }
        /// <summary>
        /// Gets or sets Batches
        /// </summary>
        public List<PrintHistoryBatchModel> Batches { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public List<PrintHistoryDeliveryNoteModel> DeliveryNotes { get; set; }
        /// <summary>
        /// Gets or sets NotificationRules
        /// </summary>
        public List<PrintHistoryNotificationRuleModel> NotificationRules { get; set; }

    }
}