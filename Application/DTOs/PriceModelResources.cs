using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{		
	public static class PriceModelResources
	{
		private const string ResourceName = "PriceModelResources";

		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Manual 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Manual"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PriceCategoryChoice 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Price Category Choice"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string UserDefined 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "User Defined"); 
			}
		}
 
    }			
}
