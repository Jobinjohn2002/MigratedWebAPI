using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OmniSearchCustomerDetail
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// OmniSearchCustomerDetail
    /// </summary>
    public class OmniSearchCustomerDetail
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <remarks></remarks>
        public OmniSearchCustomerDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customerStatusId"></param>
        /// <param name="customerName"></param>
        /// <param name="created"></param>
        /// <param name="revision"></param>
        /// <param name="facilityName"></param>
        /// <param name="facilityId"></param>
        /// <param name="customerGroupName"></param>
        /// <param name="customerGroupId"></param>
        /// <param name="isArchived"></param>
        public OmniSearchCustomerDetail(int customerId,
                                        int customerStatusId,
                                        string customerName,
                                        DateTime created,
                                        int revision,
                                        string facilityName,
                                        short facilityId,
                                        string customerGroupName,
                                        int? customerGroupId,
                                        bool isArchived
                                        )
        {
            CustomerId = customerId;
            CustomerStatusId = customerStatusId;
            CustomerName = customerName;
            Created = created;
            Revision = revision;
            FacilityName = facilityName;
            FacilityId = facilityId;
            CustomerGroupId = customerGroupId;
            CustomerGroupName = customerGroupName;
            IsArchived = isArchived;
        }

        #region IOmniSearchCustomerDetail Members

        /// <summary>
        /// Gets or sets the customer uid.
        /// </summary>
        /// <value>The customer uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer status id.
        /// </summary>
        /// <value>The customerstatusid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the customer uid.
        /// </summary>
        /// <value>The customer uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the facility.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets the facility uid.
        /// </summary>
        /// <value>The facility uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets the facility.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerGroupName
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Gets or sets the facility uid.
        /// </summary>
        /// <value>The facility uid.</value>
        /// <remarks></remarks>
        public int? CustomerGroupId { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }

        #endregion
    }
}