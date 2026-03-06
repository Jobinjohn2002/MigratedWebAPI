using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyQualityHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Quality concreteQuality, Quality genericQuality)
        {
					
			concreteQuality.QualityId = genericQuality.QualityId;			
			concreteQuality.Text = genericQuality.Text;
		}
	}
}
		