using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LogDefect
    /// </summary>
    public class LogDefect
    {
        public string FullName;
        public int UserId;
        public int? TurnaroundExternalId;
        public int? TurnaroundId;
        public int? InstanceId;
        public string ExternalId;
        public short FacilityId;
        public int StationTypeId;
        public int StationId;
        public int? EventType;
        public int? ParentTurnaroundId;
        public int? ParentItemTypeId;
        public int? Data;
        public int? Count;
        public int? PinReason;
        public bool IsApplyingEvent;
    }
}