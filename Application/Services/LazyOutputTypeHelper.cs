using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOutputTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OutputType concreteOutputType, OutputType genericOutputType)
        {
					
			concreteOutputType.OutputTypeId = genericOutputType.OutputTypeId;			
			concreteOutputType.Text = genericOutputType.Text;
		}
	}
}
		