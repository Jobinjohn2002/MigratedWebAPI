using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserDeliveryPointDataContract
    /// </summary>
    public class UserDeliveryPointDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<CustomerDataContract> Customers { get; set; }
   
    }
}