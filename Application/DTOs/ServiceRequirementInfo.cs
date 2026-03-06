using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceRequirementInfo
    /// </summary>
    public class ServiceRequirementInfo
    {
        public int Id
        {
            get; set;
        }
        public int DefinitionId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public bool IsFastTrack
        {
            get; set;
        }
    }
}
