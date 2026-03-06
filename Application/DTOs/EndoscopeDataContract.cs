using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopeDataContract
    /// </summary>
    public class EndoscopeDataContract : AssetDetailsDataContract
    {
        public DateTime? DateAddedToAer { get; set; }
        /// <summary>
        /// Gets or sets UserAdded
        /// </summary>
        public string UserAdded { get; set; }
        public DateTime? SterileExpiryDateTime { get; set; }
        public DateTime? AboutToExpireAtDateTime { get; set; }
        public DateTime? DryAtDateTime { get; set; }
        public EndoscopeStatus? Status{ get; set; }
        public bool? IsVacPack{ get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationText
        /// </summary>
        public string LocationText { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
    }

}