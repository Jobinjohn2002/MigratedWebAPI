using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OmniSearchDeliveryNotesDetail
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// OmniSearchDeliveryNotesDetail
    /// </summary>
    public class OmniSearchDeliveryNotesDetail
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <remarks></remarks>
        public OmniSearchDeliveryNotesDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="deliveryNoteId">The deliverynote id.</param>
        /// <param name="printedUserId">The printed user id.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="externalId">The external id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="facilityName">Name of the facility.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <param name="printStatus">if set to <c>true</c> [print status].</param>
        /// <param name="printed">The printed.</param>
        /// <remarks></remarks>
        public OmniSearchDeliveryNotesDetail(int deliveryNoteId,int printedUserId,string userName,                                             
                                             string externalId,
                                             short facilityId,
                                             string facilityName,
                                             int customerId,
                                             int customerStatusId,
                                             string customerName,
                                             int deliveryPointId,
                                             string deliveryPointName,
                                             bool printStatus,
											 DateTime printed)
        {
            DeliveryNoteId = deliveryNoteId;
			PrintedUserId = printedUserId;
			UserName = userName;
            ExternalId = externalId;
            FacilityId = facilityId;
            FacilityName = facilityName;
            CustomerId = customerId;
            CustomerStatusId = customerStatusId;
            CustomerName = customerName;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
            PrintStatus = printStatus;
            PrintedDate = printed;
        }

        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IndexId
        /// </summary>
        public int IndexId { get; set; }

        #region IOmniSearchDeliveryNotesDetail Members

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id</value>
        /// <remarks></remarks>
		/// <summary>
		/// Gets or sets PrintedUserId
		/// </summary>
		public int PrintedUserId { get; set; }

        /// <summary>
        /// Gets or sets the deliverynote id
        /// </summary>
        /// <value>The deliverynote id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public int DeliveryNoteId { get; set; }

        /// <summary>
        /// Gets or sets the  user name.
        /// </summary>
        /// <value>The user name</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the external id
        /// </summary>
        /// <value>The external id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the legacy id.
        /// </summary>
        /// <value>The legacy id</value>
        /// <remarks></remarks>
        public int? LegacyId { get; set; }

        /// <summary>
        /// Gets or sets the facility id.
        /// </summary>
        /// <value>The facility id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets the facility name
        /// </summary>
        /// <value>The facility name</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets the customer id
        /// </summary>
        /// <value>The customer id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customerstatusid
        /// </summary>
        /// <value>The customerstatusid</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the customer name
        /// </summary>
        /// <value>The name of the customer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the delivery point
        /// </summary>
        /// <value>The delivery point id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the delivery point name
        /// </summary>
        /// <value>The delivery point name</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the print status
        /// </summary>
        /// <value>The print status</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets PrintStatus
        /// </summary>
        public bool PrintStatus { get; set; }

        /// <summary>
        /// Gets or sets the create date
        /// </summary>
        /// <value>The create date</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// gets or sets printed data
        /// </summary>
        /// <summary>
        /// Gets or sets PrintedDate
        /// </summary>
        public DateTime PrintedDate { get; set; }

        #endregion
    }
}