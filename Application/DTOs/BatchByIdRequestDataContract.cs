using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchByIdRequestDataContract
    /// </summary>
    public class BatchByIdRequestDataContract : BaseRequestDataContract
    {
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets BatchExternalId
        /// </summary>
        public string BatchExternalId { get; set; }
        public int? MachineId { get; set; }

    }
}