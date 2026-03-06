using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    class TurnaroundEventType
    {
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public TurnAroundEventTypeIdentifier Type { get; set; }
        /// <summary>
        /// Gets or sets IsProcessEvent
        /// </summary>
        public bool IsProcessEvent { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

    }
}