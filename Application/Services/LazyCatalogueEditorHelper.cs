using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCatalogueEditorHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CatalogueEditor concreteCatalogueEditor, CatalogueEditor genericCatalogueEditor)
        {
					
			concreteCatalogueEditor.CatalogueEditorId = genericCatalogueEditor.CatalogueEditorId;			
			concreteCatalogueEditor.OwnerId = genericCatalogueEditor.OwnerId;			
			concreteCatalogueEditor.UserId = genericCatalogueEditor.UserId;
		}
	}
}
		