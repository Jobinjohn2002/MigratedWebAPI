using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadAlerts_Result
    {
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public int Identifier { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemDescription
        /// </summary>
        public string ItemDescription { get; set; }
        /// <summary>
        /// Gets or sets SynergyItemType
        /// </summary>
        public int SynergyItemType { get; set; }
    }
}
