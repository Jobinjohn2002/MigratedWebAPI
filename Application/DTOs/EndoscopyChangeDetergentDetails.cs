using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyChangeDetergentDetails
    /// </summary>
    public class EndoscopyChangeDetergentDetails
    {
        public int? MachineDetergentId;
        public int MachineId;
        public string DetergentInformation;
        public string BatchInformation;
        public bool Archived;
    }
}
