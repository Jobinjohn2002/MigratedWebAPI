using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueVendorInfo
    /// </summary>
    public class CatalogueVendorInfo
    {
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ModifiedDate
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }

    public static class CustomerExt
    {
        /// <summary>
        /// ToCatalogueVendorInfo operation
        /// </summary>
        public static IQueryable<CatalogueVendorInfo> ToCatalogueVendorInfo(this IQueryable<Synergy.Data.Customer> customers)
        {
            return customers.Select(cust => new CatalogueVendorInfo
            {
                VendorId = cust.CustomerDefinitionId,
                ModifiedDate = cust.Created,
                Name = cust.Text
            });
        }
    }
}