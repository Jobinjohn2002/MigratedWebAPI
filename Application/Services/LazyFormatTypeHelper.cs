using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFormatTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FormatType concreteFormatType, FormatType genericFormatType)
        {
					
			concreteFormatType.FormatTypeId = genericFormatType.FormatTypeId;			
			concreteFormatType.Text = genericFormatType.Text;
		}
	}
}
		