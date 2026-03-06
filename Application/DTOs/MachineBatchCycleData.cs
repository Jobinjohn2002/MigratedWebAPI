using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class MachineBatchCycleData 
	{
        public MachineBatchCycleData()
        {

        }
        /// <summary>
        /// Gets or sets CycleName
        /// </summary>
        public string CycleName { get; set; }
	}
}
		