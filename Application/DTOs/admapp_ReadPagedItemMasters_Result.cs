using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadPagedItemMasters_Result
    {
        /// <summary>
        /// Gets or sets TotalRows
        /// </summary>
        public Nullable<int> TotalRows { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinition
        /// </summary>
        public int ItemMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets RowIndex
        /// </summary>
        public Nullable<long> RowIndex { get; set; }
    }
}
