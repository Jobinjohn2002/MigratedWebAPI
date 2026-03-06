using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IMSUserCustomerResponse
    /// </summary>
    public class IMSUserCustomerResponse
    {
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<IMSUserCustomer> Customers { get; set; }
    }

    /// <summary>
    /// IMSUserCustomer
    /// </summary>
    public class IMSUserCustomer
    {
        /// <summary>
        /// The customer definition Id
        /// </summary>
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Name of the customer
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
    }
}
