using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class MultiFacilityProcessingData 
	{
        public MultiFacilityProcessingData()
        {

        }
        /// <summary>
        /// Gets or sets IsPrimary
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets AlternateProcessingFacilityName
        /// </summary>
        public string AlternateProcessingFacilityName { get; set; }
        /// <summary>
        /// Gets or sets RequestedByName
        /// </summary>
        public string RequestedByName { get; set; }
        /// <summary>
        /// Gets or sets RequestedDate
        /// </summary>
        public DateTime RequestedDate { get; set; }
        /// <summary>
        /// Gets or sets AcceptedByName
        /// </summary>
        public string AcceptedByName { get; set; }
        public bool? IsRejected { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityProcessHandShakeId
        /// </summary>
        public int MultiFacilityProcessHandShakeId { get; set; }
        public bool? PrimaryIsEnable { get; set; }
        public bool? AlternativeIsEnable { get; set; }
        /// <summary>
        /// Gets or sets ModifiedByName
        /// </summary>
        public string ModifiedByName { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityProcessStatusId
        /// </summary>
        public byte MultiFacilityProcessStatusId { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityProcessStatusText
        /// </summary>
        public string MultiFacilityProcessStatusText { get; set; }
	}
}
		