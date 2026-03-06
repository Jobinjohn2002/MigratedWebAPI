using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserCustomerDetail
    /// </summary>
    public class UserCustomerDetail
    {
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<CustomerDetails> Customers { get; set; }

        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public SettingsConfirmation Confirmation { get; set; }
    }

    /// <summary>
    /// UserCustomers
    /// </summary>
    public class UserCustomers 
    {
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<CustomerDetails> Customers { get; set; }
    }

    /// <summary>
    /// CustomerDetails
    /// </summary>
    public class CustomerDetails
    {
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
        /// <summary>
        /// Gets or sets TenancyName
        /// </summary>
        public string TenancyName { get; set; }

        /// <summary>
        /// Gets or sets Selected
        /// </summary>
        public bool Selected { get; set; }
    }
}