using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemTypeDataContract
    /// </summary>
    public class ItemTypeDataContract
    {
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }
    }
}
