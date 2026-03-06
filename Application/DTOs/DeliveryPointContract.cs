using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class DeliveryPointContract 
	{
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public AddressData Address { get; set; }
	}
}
		