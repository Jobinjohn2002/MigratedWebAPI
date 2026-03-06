using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OutOfQuarantineData
    /// </summary>
    public class OutOfQuarantineData
    {
        /// <summary>
        /// Gets or sets RerouteEvents
        /// </summary>
        public List<EventTypeData> RerouteEvents { get; set; }
        /// <summary>
        /// Gets or sets HasActiveDefect
        /// </summary>
        public bool HasActiveDefect { get; set; }
        /// <summary>
        /// Gets or sets IsPreWash
        /// </summary>
        public bool IsPreWash { get; set; }
    }
}
