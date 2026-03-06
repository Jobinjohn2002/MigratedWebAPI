using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class CustomerItemTypeData
    {
        public CustomerItemTypeData() { }
        public CustomerItemTypeData(short customerDefinitionId, short itemTypeId, string itemTypeName)
        {
            CustomerDefinitionId = customerDefinitionId;

            ItemTypeId = itemTypeId;
            
            ItemTypeName = itemTypeName;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ParentItemTypeName
        /// </summary>
        public string ParentItemTypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ParentItemTypeId
        /// </summary>
        public int ParentItemTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Selected { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ExpiryDays { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets IsComponent
        /// </summary>
        public bool IsComponent { get; set; }

    }
}

