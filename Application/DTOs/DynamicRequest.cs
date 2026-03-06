using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DynamicRequest
    /// </summary>
    public class DynamicRequest<T> : BaseRequestDataContract
    {
        public T Value
        {
            get; set;
        }
    }
}
