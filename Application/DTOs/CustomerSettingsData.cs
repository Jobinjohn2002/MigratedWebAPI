using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// CustomerSettingsData
    /// </summary>
    public class CustomerSettingsData
    {
        public int CustomerSettingId;
        public int CustomerDefinitionId;
        public string Name;
        public string value;
    }
}
