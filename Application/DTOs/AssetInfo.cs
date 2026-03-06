using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes an asset, such as a surgical tray or set.  An asset represents a physical identifiable instance of a product owned.
    /// </summary>
    /// <summary>
    /// AssetInfo
    /// </summary>
    public class AssetInfo
    {
        /// <summary>
        /// [Reserved] - for future use (to uniquely identify the asset) - please refer to the Identifiers property which includes all identifiers for the Asset)
        /// </summary>
        /// <summary>
        /// Gets or sets AssetNumber
        /// </summary>
        public string AssetNumber { get; set; }

        /// <summary>
        /// The product number idenfiying the type of product this asset is an instance of.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The identifiers of the product, such as printed or etched barcodes and RFID tags.
        /// </summary>
        /// <summary>
        /// Gets or sets Identifiers
        /// </summary>
        public List<Identifier> Identifiers { get; set; }

        /// <summary>
        /// <code>True</code> if the asset is active and <code>False</code> if the asset is inactive/archived.
        /// </summary>
        /// <summary>
        /// Gets or sets Active
        /// </summary>
        public bool Active { get; set; }
    }
}