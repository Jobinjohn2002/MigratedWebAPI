using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ScanEventDataContract
    /// </summary>
    public class ScanEventDataContract
    {
        public int EventType;
        public int? BatchId;
        public bool IsChargeable;
    }
}