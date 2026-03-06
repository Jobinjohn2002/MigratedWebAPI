using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Product Specification Info.
    /// </summary>
    /// <summary>
    /// ProductSpecificationInfo
    /// </summary>
    public class ProductSpecificationInfo
    {
        /// <summary>
        /// Describes the product this specification is for.
        /// </summary>
        /// <summary>
        /// Gets or sets Product
        /// </summary>
        public ProductInfo Product { get; set; }

        /// <summary>
        /// Describes the specification of the product.
        /// </summary>
        /// <summary>
        /// Gets or sets Specification
        /// </summary>
        public SpecificationInfo Specification { get; set; }
    }
}