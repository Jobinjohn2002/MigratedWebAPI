using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StockInModel
    /// </summary>
    public class StockInModel
    {
        public int? SelectedStoragePointId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public string TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyPrimaryId
        /// </summary>
        public string TrolleyPrimaryId { get; set; }
        /// <summary>
        /// Gets or sets StoragePoints
        /// </summary>
        public List<StoragePointSummary> StoragePoints { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundTable
        /// </summary>
        public TableModel TurnaroundTable { get; set; }
    }

    /// <summary>
    /// StoragePointSummary
    /// </summary>
    public class StoragePointSummary
    {
        /// <summary>
        /// Gets or sets StoragePointId
        /// </summary>
        public int StoragePointId { get; set; }
        /// <summary>
        /// Gets or sets StoragePointText
        /// </summary>
        public string StoragePointText { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerText
        /// </summary>
        public string CustomerText { get; set; }
        /// <summary>
        /// Gets or sets AdditionalDetails
        /// </summary>
        public string AdditionalDetails { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets LocationExternalId
        /// </summary>
        public string LocationExternalId { get; set; }
    }
}