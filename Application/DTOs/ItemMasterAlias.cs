using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ItemMasterAlias 
	{
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets CustomerText
        /// </summary>
        public string CustomerText { get; set; }

        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPointText
        /// </summary>
        public string DeliveryPointText { get; set; }

        /// <summary>
        /// Gets or sets ItemMasterText
        /// </summary>
        public string ItemMasterText { get; set; }

        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; set; }   
 
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }

        /// <summary>
        /// Gets or sets CustomerGroupText
        /// </summary>
        public string CustomerGroupText { get; set; }

        public int? ItemCount { get; set; }

        /// <summary>
        /// Gets or sets CustomerAlias
        /// </summary>
        public string CustomerAlias { get; set; }

        /// <summary>
        /// Gets or sets CustomerGroupAlias
        /// </summary>
        public string CustomerGroupAlias { get; set; }

        /// <summary>
        /// Gets or sets TrayCount
        /// </summary>
        public int TrayCount { get; set; }
	}
}
		