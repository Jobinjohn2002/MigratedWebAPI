using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTranslationHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Translation concreteTranslation, Translation genericTranslation)
        {
					
			concreteTranslation.Application = genericTranslation.Application;			
			concreteTranslation.LanguageSet = genericTranslation.LanguageSet;			
			concreteTranslation.Culture = genericTranslation.Culture;			
			concreteTranslation.SectionGroup = genericTranslation.SectionGroup;			
			concreteTranslation.Section = genericTranslation.Section;			
			concreteTranslation.From = genericTranslation.From;			
			concreteTranslation.To = genericTranslation.To;
		}
	}
}
		