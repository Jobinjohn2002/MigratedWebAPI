using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// KeyValuesDataContract
    /// </summary>
    public class KeyValuesDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets KeyValues
        /// </summary>
        public List<KeyValueDataContract> KeyValues { get; set; }
    }
}