using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class StationData
	{
        public StationData()
        {

        }

        public StationData(IStation genericObj, IStationType stationType, IList<IStationType> associatedStationTypes)
			: this(genericObj)
		{
			StationType = new StationTypeData(stationType);
			StationTypeName = stationType.Text;
			AssociatedStationTypes = associatedStationTypes.Select(ast => new StationTypeData(ast)).ToList();
		}

		#region Extra data
		/// <summary>
		/// Gets or sets FacilityName
		/// </summary>
		public string FacilityName { get; set; }
		/// <summary>
		/// Gets or sets StationType
		/// </summary>
		public StationTypeData StationType { get; set; }
		/// <summary>
		/// Gets or sets StationTypeName
		/// </summary>
		public string StationTypeName { get; set; }
        /// <summary>
        /// Gets or sets PinRequestReson
        /// </summary>
        public string PinRequestReson { get; set; }
		/// <summary>
		/// Gets or sets AssociatedStationTypes
		/// </summary>
		public IList<StationTypeData> AssociatedStationTypes { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets LocationCode
        /// </summary>
        public string LocationCode { get; set; }

		#endregion
	}
}