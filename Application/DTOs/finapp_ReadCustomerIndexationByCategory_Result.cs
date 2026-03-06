using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class finapp_ReadCustomerIndexationByCategory_Result
    {
        /// <summary>
        /// Gets or sets IndexationCategoryId
        /// </summary>
        public byte IndexationCategoryId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets IndexationFactor
        /// </summary>
        public Nullable<decimal> IndexationFactor { get; set; }
    }
}
