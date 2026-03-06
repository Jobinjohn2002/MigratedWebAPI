using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class UserClockingEventData 
	{
	    public UserClockingEventData()
	    {
	        
	    }
        /// <summary>
        /// Gets or sets Operator
        /// </summary>
        public UserData Operator { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public LocationData Location { get; set; }
	}
}
		