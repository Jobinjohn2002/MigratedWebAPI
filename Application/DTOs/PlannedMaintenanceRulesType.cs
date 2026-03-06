using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum PlannedMaintenanceRulesType
    {
        [EnumMember]
        [Description("Running Planned Maintenance Rules and creating Maintenance Reports.")]
        MaintenanceReports=1,

        [EnumMember]
        [Description("Displaying Planned Maintenance Warning.")]
        MaintenanceWarning=2,

        [EnumMember]
        [Description("Put turnaround into Quarantine Maintenance.")]
        MaintenanceIntoQuarantine=4, 
    }
}
