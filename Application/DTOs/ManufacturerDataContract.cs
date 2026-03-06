using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ManufacturerListDataContract
    /// </summary>
    public class ManufacturerListDataContract
    {
        /// <summary>
        /// Gets or sets Manufacturers
        /// </summary>
        public List<ManufacturerDataContract> Manufacturers { get; set; }

    }

    [Serializable]
    /// <summary>
    /// ManufacturerDataContract
    /// </summary>
    public class ManufacturerDataContract
    {
        /// <summary>
        /// Gets or sets ManufacturerId
        /// </summary>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

    }
}
