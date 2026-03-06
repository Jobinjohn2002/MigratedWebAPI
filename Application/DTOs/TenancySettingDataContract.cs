using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// TenancySettingDataContract
    /// </summary>
    public class TenancySettingDataContract
    {
        public int TenancySettingId;
        public int TenancyId;
        public string Name;
        public int Type;
        public string Value;
    }
}
