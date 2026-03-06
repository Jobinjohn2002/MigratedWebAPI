using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProcessRequest
    /// </summary>
    public class ProcessRequest : BaseRequestDataContract
    {
        public byte[] Content { get; set; }
    }
}
