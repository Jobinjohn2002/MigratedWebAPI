using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// EventTypeDataContract
    /// </summary>
    public class EventTypeDataContract
    {
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets NextEventText
        /// </summary>
        public string NextEventText { get; set; }
    }
}