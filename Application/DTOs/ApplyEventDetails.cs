using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ApplyEventDetails
    /// </summary>
    public class ApplyEventDetails
    {
        public string ExternalId;
        public int? TurnaroundId;
        public int UserId;
        public short FacilityId;
        public int StationTypeId;
        public int StationId;
        public int? EventType;
        public int? Data;
        public int? Count;
        public int? PinReason;
    }
}