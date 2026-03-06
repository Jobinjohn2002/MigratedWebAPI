using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class FastTrackRequestData 
	{
        public FastTrackRequestData()
        {
        }

        /// <summary>
        /// Delivery Point Name
        /// </summary>
	    /// <summary>
	    /// Gets or sets DeliveryPointName
	    /// </summary>
	    public string DeliveryPointName { get; set; }
        /// <summary>
        /// Status name 
        /// </summary>
        /// <summary>
        /// Gets or sets StatusName
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// ContainerMaster text
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }
        /// <summary>
        /// Container Master External Id
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Container Master Id
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        ///  First Name
        /// </summary>
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Surname
        /// </summary>
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// EnquiryStatusText
        /// </summary>
        /// <summary>
        /// Gets or sets EnquiryStatusText
        /// </summary>
        public string EnquiryStatusText { get; set; }
        /// <summary>
        /// TotalCount
        /// </summary>
        /// <summary>
        /// Gets or sets TotalCount
        /// </summary>
        public int TotalCount { get; set; }

	}
}
		