using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLeafHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Leaf concreteLeaf, Leaf genericLeaf)
        {
					
			concreteLeaf.LeafId = genericLeaf.LeafId;			
			concreteLeaf.TreeId = genericLeaf.TreeId;			
			concreteLeaf.Lft = genericLeaf.Lft;			
			concreteLeaf.Rgt = genericLeaf.Rgt;
		}
	}
}
		