using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFormatHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Format concreteFormat, Format genericFormat)
        {
					
			concreteFormat.FormatId = genericFormat.FormatId;			
			concreteFormat.FormatTypeId = genericFormat.FormatTypeId;			
			concreteFormat.Text = genericFormat.Text;
		}
	}
}
		