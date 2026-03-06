using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ProductionItem
    /// </summary>
    public class ProductionItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductionItem"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="containerInstancePrimaryId">The container instance primary id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="stationExpiry">The station expiry.</param>
        /// <param name="timeAtLocation">The time at location.</param>
        /// <param name="expiryTime">The expiry time.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="serviceRequirementName">Name of the service requirement.</param>
        /// <param name="bookmark">The bookmark.</param>
        /// <remarks></remarks>
        public ProductionItem(
            int turnaroundId,
            int instanceId,
            string containerInstancePrimaryId,
            string itemName,
            int customerId,
            string customerName,
            string stationExpiry,
            DateTime timeAtLocation,
            DateTime expiryTime,
            int serviceRequirementId,
            string serviceRequirementName,
            string bookmark)
        {
            TurnaroundId = turnaroundId;
            InstanceId = instanceId;
            ContainerInstancePrimaryId = containerInstancePrimaryId;
            ItemName = itemName;
            CustomerId = customerId;
            CustomerName = customerName;
            StationExpiry = stationExpiry;
            TimeAtLocation = timeAtLocation;
            ExpiryTime = expiryTime;
            ServiceRequirementId = serviceRequirementId;
            ServiceRequirementName = serviceRequirementName;
            Bookmark = bookmark;
        }
        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets InstanceId
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the container instance external id.
        /// </summary>
        /// <value>The container instance external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>The customer id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the station expiry.
        /// </summary>
        /// <value>The station expiry.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets StationExpiry
        /// </summary>
        public string StationExpiry { get; set; }

        /// <summary>
        /// Gets or sets the time at location.
        /// </summary>
        /// <value>The time at location.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TimeAtLocation
        /// </summary>
        public DateTime TimeAtLocation { get; set; }

        /// <summary>
        /// Gets or sets the expiry time.
        /// </summary>
        /// <value>The expiry time.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExpiryTime
        /// </summary>
        public DateTime ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the service requirement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service requirement.
        /// </summary>
        /// <value>The name of the service requirement.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }

        /// <summary>
        /// Gets or sets the bookmark.
        /// </summary>
        /// <value>The bookmark.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Bookmark
        /// </summary>
        public string Bookmark { get; set; }
    }
}
