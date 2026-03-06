using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DynamicReply
    /// </summary>
    public class DynamicReply<T> : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public T Value { get; set; }
    }
}
