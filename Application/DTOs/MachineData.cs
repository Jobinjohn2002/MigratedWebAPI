using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class MachineData
    {
        public MachineData()
        {

        }
        /// <summary>
        /// Gets or sets MachineEvent
        /// </summary>
        public MachineEventData MachineEvent { get; set; }
        /// <summary>
        /// Gets or sets MachineBatchCycles
        /// </summary>
        public List<MachineBatchCycleData> MachineBatchCycles { get; set; }
        /// <summary>
        /// Gets or sets Shelves
        /// </summary>
        public List<MachineShelf> Shelves { get; set; }
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public List<MachineSettingData> Settings { get; set; }
        public int? MachineGroupId { get; set; }
        /// <summary>
        /// Gets or sets NewMachineGroupName
        /// </summary>
        public string NewMachineGroupName { get; set; }

        public MachineData(IMachine genericObj, MachineEventData machineEvent)
            : this(genericObj)
        {
            MachineEvent = machineEvent;
        }
        /// <summary>
        /// Gets or sets MachineLocations
        /// </summary>
        public List<LocationData> MachineLocations { get; set; }
        /// <summary>
        /// MachineShelf
        /// </summary>
        public class MachineShelf
        {
            public MachineShelf(string name, int locationId)
            {
                Name = name;
                LocationId = locationId;
            }
            /// <summary>
            /// Gets or sets Name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets LocationId
            /// </summary>
            public int LocationId { get; set; }
        }
	}
}
