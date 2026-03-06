using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{		
	public static class DateTimeFormatResources
	{
		private const string ResourceName = "DateTimeFormatResources";

		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_LongDateFormatText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_LongDateFormatText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_LongTimeFormatText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_LongTimeFormatText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_ShortDateFormatText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_ShortDateFormatText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_ShortTimeFormatText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_ShortTimeFormatText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_TimeZoneText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_TimeZoneText"); 
			}
		}
 
    }			
}
