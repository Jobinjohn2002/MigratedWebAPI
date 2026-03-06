using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// OmniSearchDeliveryNotesDetail interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchDeliveryNotesDetail
    /// </summary>
    public interface IOmniSearchDeliveryNotesDetail
    {
        /// <summary>
        /// Gets or sets the deliverynote id
        /// </summary>
        /// <value>The deliverynote id</value>
        /// <remarks></remarks>
        int DeliveryNoteId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id</value>
        /// <remarks></remarks>
        int PrintedUserId { get; set; }

        /// <summary>
        /// Gets or sets the  user name.
        /// </summary>
        /// <value>The user name</value>
        /// <remarks></remarks>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the external id
        /// </summary>
        /// <value>The external id</value>
        /// <remarks></remarks>
        string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the legacy id.
        /// </summary>
        /// <value>The legacy id</value>
        /// <remarks></remarks>
        int? LegacyId { get; set; }

        /// <summary>
        /// Gets or sets the facility id.
        /// </summary>
        /// <value>The facility id.</value>
        /// <remarks></remarks>
        short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets the facility name
        /// </summary>
        /// <value>The facility name</value>
        /// <remarks></remarks>
        string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets the customer id
        /// </summary>
        /// <value>The customer id</value>
        /// <remarks></remarks>
        int CustomerId { get; set; }

        int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the customer name
        /// </summary>
        /// <value>The name of the customer.</value>
        /// <remarks></remarks>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the delivery point
        /// </summary>
        /// <value>The delivery point id</value>
        /// <remarks></remarks>
        int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the delivery point name
        /// </summary>
        /// <value>The delivery point name</value>
        /// <remarks></remarks>
        string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the print status
        /// </summary>
        /// <value>The print status</value>
        /// <remarks></remarks>
        bool PrintStatus { get; set; }

        /// <summary>
        /// Gets or sets the create date
        /// </summary>
        /// <value>The create date</value>
        /// <remarks></remarks>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the printed date
        /// </summary>
        /// <value>The create date</value>
        /// <remarks></remarks>
        DateTime PrintedDate { get; set; }
    }
}