using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class MultiFacilityProcessHandShakeData
    {
        public MultiFacilityProcessHandShakeData()
        {

        }
        /// <summary>
        /// Gets or sets RequestedByName
        /// </summary>
        public string RequestedByName { get; set; }
        /// <summary>
        /// Gets or sets AlternateProcessingFacilityName
        /// </summary>
        public string AlternateProcessingFacilityName { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets AcceptedDate
        /// </summary>
        public DateTime AcceptedDate { get; set; }
        /// <summary>
        /// Gets or sets AcceptedBy
        /// </summary>
        public string AcceptedBy { get; set; }
        /// <summary>
        /// Gets or sets AcceptedFacility
        /// </summary>
        public string AcceptedFacility { get; set; }
        /// <summary>
        /// Gets or sets RequestedByFirstName
        /// </summary>
        public string RequestedByFirstName { get; set; }
    }
}
