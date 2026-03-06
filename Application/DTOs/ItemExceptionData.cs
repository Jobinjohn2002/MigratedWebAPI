using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ItemExceptionData 
	{
        public ItemExceptionData()
        {

        }
        /// <summary>
        /// Gets or sets ItemExceptionReasonText
        /// </summary>
        public string ItemExceptionReasonText { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterText
        /// </summary>
        public string ItemMasterText { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
    }
}
		