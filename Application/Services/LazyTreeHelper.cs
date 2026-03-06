using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTreeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Tree concreteTree, Tree genericTree)
        {
					
			concreteTree.TreeId = genericTree.TreeId;			
			concreteTree.OwnerId = genericTree.OwnerId;			
			concreteTree.Text = genericTree.Text;
		}
	}
}
		