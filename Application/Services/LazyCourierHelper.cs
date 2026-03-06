using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCourierHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Courier concreteCourier, Courier genericCourier)
        {
					
			concreteCourier.CourierId = genericCourier.CourierId;			
			concreteCourier.Text = genericCourier.Text;
		}
	}
}
		