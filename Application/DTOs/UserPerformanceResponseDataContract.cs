using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserPerformanceResponseDataContract
    /// </summary>
    public class UserPerformanceResponseDataContract : BaseReplyDataContract
    {
        public double? PercentageIpohVariance { get; set; }
    }
}
