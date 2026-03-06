using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Omni Search Delivery Point Detail
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// OmniSearchDeliveryPointDetail
    /// </summary>
    public class OmniSearchDeliveryPointDetail
    {
        public OmniSearchDeliveryPointDetail()
        { }

        public OmniSearchDeliveryPointDetail(int deliveryPointId, string name, string customerName)
        {
            DeliveryPointId = deliveryPointId;
            CustomerName = customerName;
            Name = name;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Customer Name .
        /// </summary>
        /// <value>The Customer Name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the Delivery Point Id.
        /// </summary>
        /// <value>The Delivery Point Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

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
