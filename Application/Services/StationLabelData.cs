using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// StationLabelData
    /// </summary>
    public class StationLabelData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public StationLabelData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceLabelData"/> class.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="customerGs1">The customer GS1.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <param name="instanceExternalId">The instance external id.</param>
        /// <remarks></remarks>
        public StationLabelData(string stationName,
                                string customerName,
                                string customerGs1,
                                string stationType,
                                string ntLogon)
        {
            CustomerName = customerName;
            CustomerGs1 = customerGs1;
            StationName = stationName;
            NTLogon = ntLogon;
            StationType = stationType;
        }

        #region Properties

        /// <summary>
        /// Gets the name of the station.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets StationName
        /// </summary>
        public string StationName { get; private set; }

        /// <summary>
        /// Gets the NTLogon.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets NTLogon
        /// </summary>
        public string NTLogon { get; private set; }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; private set; }

        /// <summary>
        /// Gets the customer GS1.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerGs1
        /// </summary>
        public string CustomerGs1 { get; private set; }

        /// <summary>
        /// Gets the type of station.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public string StationType { get; private set; }

        #endregion
    }
}