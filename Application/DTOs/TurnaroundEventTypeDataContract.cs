using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundEventTypeDataContract
    /// </summary>
    public class TurnaroundEventTypeDataContract
    {
        /// <summary>
        /// Event Type Id
        /// </summary>
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }

        /// <summary>
        /// Event Text
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is Process Event
        /// </summary>
        /// <summary>
        /// Gets or sets IsProcessEvent
        /// </summary>
        public bool IsProcessEvent { get; set; }

        /// <summary>
        /// Event Type Id
        /// </summary>
        /// <summary>
        /// Gets or sets CategoryId
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// ToString operation
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

    }
}
