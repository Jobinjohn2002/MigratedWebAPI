using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityInfoDataContract
    /// </summary>
    public class FacilityInfoDataContract
    {
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Address1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Gets or sets Address2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// Gets or sets Address3
        /// </summary>
        public string Address3 { get; set; }
        /// <summary>
        /// Gets or sets City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets Postcode
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        public string Telephone { get; set; }
    }
}