using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class EventTypeData 
	{
        public EventTypeData()
        {
        }

        /// <summary>
        /// The number of turnarounds associated with this event tyoe
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }
	}
}
		