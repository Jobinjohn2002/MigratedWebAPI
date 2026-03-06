using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyChangeDetergentRequest
    /// </summary>
    public class EndoscopyChangeDetergentRequest : BaseRequestDataContract
    {
        public List<EndoscopyChangeDetergentDetails> EndoscopyChangeDetergentDetails;
    }
}
