using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ItemInstanceContract 
	{
        /// <summary>
        /// Gets or sets Identifiers
        /// </summary>
        public List<ItemInstanceIdentifierContract> Identifiers { get; set; }
	    public int? ContainerContentPosition { get; set; }

    }
}
		