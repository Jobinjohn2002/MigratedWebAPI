using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDocumentHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Document concreteDocument, Document genericDocument)
        {
					
			concreteDocument.DocumentId = genericDocument.DocumentId;			
			concreteDocument.DocumentTypeId = genericDocument.DocumentTypeId;			
			concreteDocument.FileName = genericDocument.FileName;
		}
	}
}
		