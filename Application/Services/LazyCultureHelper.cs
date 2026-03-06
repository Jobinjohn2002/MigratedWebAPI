using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCultureHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Culture concreteCulture, Culture genericCulture)
        {
					
			concreteCulture.CultureId = genericCulture.CultureId;			
			concreteCulture.Text = genericCulture.Text;			
			concreteCulture.Code = genericCulture.Code;
		}
	}
}
		