using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum OrderEmailType
    {
        NewOrderEmail,
        UpdatedOrderEmail,
        OrderCommentEmail
    }

    /// <summary>
    /// OrderEmailModel
    /// </summary>
    public class OrderEmailModel
    {
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public OrderEmailType Type { get; set; }
        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public OrderDetailsModel Details { get; set; }
    }
}