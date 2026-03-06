using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PDFContent
    /// </summary>
    public class PDFContent
    {
        public byte[] Bytes { get; set; }
    }
}
