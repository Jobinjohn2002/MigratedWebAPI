using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerWithName
    /// </summary>
    public class CustomerWithName
    {
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public ICustomer Customer { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets GroupName
        /// </summary>
        public string GroupName { get; set; }
    }
}
