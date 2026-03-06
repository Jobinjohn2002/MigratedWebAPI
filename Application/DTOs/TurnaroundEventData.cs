using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class TurnaroundEventData
	{
		public TurnaroundEventData(ITurnaroundEvent turnaroundEvent, string eventTypeName, string userName, string stationName)
			: this(turnaroundEvent)
		{
			EventTypeName = eventTypeName;
			UserName = userName;
			StationName = stationName;
		}
		#region Extra Members
		/// <summary>
		/// Gets or sets EventTypeName
		/// </summary>
		public string EventTypeName { get; set; }
		/// <summary>
		/// Gets or sets UserName
		/// </summary>
		public string UserName { get; set; }
		/// <summary>
		/// Gets or sets StationName
		/// </summary>
		public string StationName { get; set; }
        public int? NextEventTypeId { get; set; }

		#endregion Extra Members
	}
}