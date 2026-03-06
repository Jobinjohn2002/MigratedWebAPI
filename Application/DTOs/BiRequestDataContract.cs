using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BiRequestDataContract
    /// </summary>
    public class BiRequestDataContract : BaseRequestDataContract
    {
        public int BatchId;
        public int BatchCycleId;
        public int MachineId;
        public bool IsStartBatch;
    }
}