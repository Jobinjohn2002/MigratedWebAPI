using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Product Info.
    /// </summary>
    /// <summary>
    /// ProductInfo
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// The unique identifier for this resource.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// Your product reference, e.g. your internal system reference number to link to this record.
        /// </summary>
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// The product name.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The hospital that owns the product.
        /// </summary>
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// The product type.
        /// </summary>
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The product sub type.
        /// </summary>
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// The product category.
        /// </summary>
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// The product speciality.
        /// </summary>
        /// <summary>
        /// Gets or sets Speciality
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// The product manifest.
        /// </summary>
        /// <summary>
        /// Gets or sets Manifest
        /// </summary>
        public IEnumerable<ProductInfo> Manifest { get; set; }
        /// <summary>
        /// <code>True</code> if the product is active and <code>False</code> if the product is inactive/archived.
        /// </summary>
        /// <summary>
        /// Gets or sets Active
        /// </summary>
        public bool Active { get; set; }
    }
}