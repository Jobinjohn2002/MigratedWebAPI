using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderTemplateData
    /// </summary>
    public class OrderTemplateData
    {
        /// <summary>
        /// Gets or sets OrderTemplateId
        /// </summary>
        public int OrderTemplateId { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedById
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// Gets or sets AlternateId
        /// </summary>
        public string AlternateId { get; set; }
        /// <summary>
        /// Gets or sets BatchNumber
        /// </summary>
        public Guid BatchNumber { get; set; }
        public DateTime? ArchiveDate { get; set; }
        /// <summary>
        /// Gets or sets OrderTemplateLines
        /// </summary>
        public IEnumerable<OrderTemplateLineData> OrderTemplateLines { get; set; }
        /// <summary>
        /// Gets or sets TrayCount
        /// </summary>
        public int TrayCount { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

    }
    [Serializable]
    /// <summary>
    /// OrderTemplateListData
    /// </summary>
    public class OrderTemplateListData
    {
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<OrderTemplateData> Items { get; set; }
        /// <summary>
        /// Gets or sets ItemCount
        /// </summary>
        public int ItemCount { get; set; }
    }
}
