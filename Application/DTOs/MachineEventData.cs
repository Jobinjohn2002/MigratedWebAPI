using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class MachineEventData
	{
        public MachineEventData()
        {

        }
		/// <summary>
		/// Gets or sets MachineEventType
		/// </summary>
		public MachineEventTypeData MachineEventType { get; set; }

		public MachineEventData(IMachineEvent genericObj, MachineEventTypeData machineEventTypeData)
			: this(genericObj)
		{
			MachineEventType = machineEventTypeData;
		}
        /// <summary>
        /// Gets or sets MachineEventReasonText
        /// </summary>
        public string MachineEventReasonText { get; set; }
        /// <summary>
        /// Gets or sets MachineEventTypeText
        /// </summary>
        public string MachineEventTypeText { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserName
        /// </summary>
        public string CreatedUserName { get; set; }
        /// <summary>
        /// Gets or sets StationName
        /// </summary>
        public string StationName { get; set; }
    }
}
