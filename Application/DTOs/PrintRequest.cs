using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PrintRequest
    /// </summary>
    public class PrintRequest : BaseRequestDataContract
    {
        public string PrinterName;
        public string PrintName;
        public byte[] Data { get; set; }
    }
}