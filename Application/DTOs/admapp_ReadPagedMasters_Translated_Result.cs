using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadPagedMasters_Translated_Result
    {
        /// <summary>
        /// Gets or sets MasterType
        /// </summary>
        public int MasterType { get; set; }
        /// <summary>
        /// Gets or sets MasterId
        /// </summary>
        public int MasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets DefinitionId
        /// </summary>
        public int DefinitionId { get; set; }
        /// <summary>
        /// Gets or sets TotalRows
        /// </summary>
        public Nullable<int> TotalRows { get; set; }
        /// <summary>
        /// Gets or sets RowIndex
        /// </summary>
        public Nullable<long> RowIndex { get; set; }
    }
}
