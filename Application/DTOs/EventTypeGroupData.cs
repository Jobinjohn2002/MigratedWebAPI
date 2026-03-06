using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class EventTypeGroupData 
	{
        /// <summary>
        /// Gets or sets EventTypeIds
        /// </summary>
        public List<short> EventTypeIds { get; set; }
	}
}