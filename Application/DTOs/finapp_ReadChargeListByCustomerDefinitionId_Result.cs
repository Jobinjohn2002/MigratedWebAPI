using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class finapp_ReadChargeListByCustomerDefinitionId_Result
    {
        /// <summary>
        /// Gets or sets ChargeListId
        /// </summary>
        public int ChargeListId { get; set; }
        /// <summary>
        /// Gets or sets ChargeListCategory
        /// </summary>
        public string ChargeListCategory { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets BasePrice
        /// </summary>
        public decimal BasePrice { get; set; }
        /// <summary>
        /// Gets or sets CurrentPrice
        /// </summary>
        public Nullable<decimal> CurrentPrice { get; set; }
    }
}
