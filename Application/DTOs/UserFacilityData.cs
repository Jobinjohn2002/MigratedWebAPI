using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class UserFacilityData
	{
        public UserFacilityData()
        {
        }

		public UserFacilityData(IUserFacility genericUserFacility, string facilityName, FacilityType facilityType)
			: this(genericUserFacility)
		{
			FacilityName = facilityName;
            FacilityType = facilityType;
		}

		#region extra Members
		/// <summary>
		/// Gets or sets FacilityName
		/// </summary>
		public string FacilityName { get; set; }
        public FacilityType? FacilityType { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public FacilityData Facility { get; set; }
        public bool? ItemAliasEnabled { get; set; }
        public bool? BiologicalIndicatorEnabled { get; set; }
        /// <summary>
        /// Gets or sets AllowProcessBeforeBiCompleteType
        /// </summary>
        public int AllowProcessBeforeBiCompleteType { get; set; }
        /// <summary>
        /// Gets or sets EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public int OwnerId { get; set; }
        #endregion
	}
}