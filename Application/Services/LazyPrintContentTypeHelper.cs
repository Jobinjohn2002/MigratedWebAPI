using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintContentTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintContentType concretePrintContentType, PrintContentType genericPrintContentType)
        {
					
			concretePrintContentType.PrintContentTypeId = genericPrintContentType.PrintContentTypeId;			
			concretePrintContentType.Text = genericPrintContentType.Text;
		}
	}
}
		