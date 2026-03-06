using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// SystemSettingDataContract
    /// </summary>
    public class SystemSettingDataContract
    {
        public int SystemSettingId;
        public string Name;
        public int Type;
        public string Value;
    }
}
