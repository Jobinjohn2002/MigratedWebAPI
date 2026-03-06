using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class DeliveryPoint 
	{
        /// <summary>
        /// Gets or sets Selected
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// SelectedForUser operation
        /// </summary>
        public bool SelectedForUser(int userId)
        {
            return UserDeliveryPoints.Any(i => i.UserId == userId);
        }
	}
}
		