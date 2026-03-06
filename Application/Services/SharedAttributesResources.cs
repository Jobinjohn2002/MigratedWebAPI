using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{		
	public static class SharedAttributesResources
	{
		private const string ResourceName = "SharedAttributesResources";

		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_NewPasswordText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_NewPasswordText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string NewPassword 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "NewPassword"); 
			}
		}
 
    }			
}
