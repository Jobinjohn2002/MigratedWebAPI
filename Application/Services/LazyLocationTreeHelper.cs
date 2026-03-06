using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLocationTreeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LocationTree concreteLocationTree, LocationTree genericLocationTree)
        {
					
			concreteLocationTree.LocationTreeId = genericLocationTree.LocationTreeId;			
			concreteLocationTree.TreeId = genericLocationTree.TreeId;
		}
	}
}
		