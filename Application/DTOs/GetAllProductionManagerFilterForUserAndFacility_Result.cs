using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class GetAllProductionManagerFilterForUserAndFacility_Result
    {
        /// <summary>
        /// Gets or sets UserProductionManagerFilterId
        /// </summary>
        public int UserProductionManagerFilterId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets FilterJSON
        /// </summary>
        public string FilterJSON { get; set; }
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Gets or sets ShowInProductionOnly
        /// </summary>
        public string ShowInProductionOnly { get; set; }
        /// <summary>
        /// Gets or sets IncludeStock
        /// </summary>
        public string IncludeStock { get; set; }
    }
}
