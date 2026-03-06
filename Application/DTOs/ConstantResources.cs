using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{		
	public static class ConstantResources
	{
		private const string ResourceName = "ConstantResources";

		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_CustomerNotFoundText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_CustomerNotFoundText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_DateText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_DateText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_DecimalText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_DecimalText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_EditPasswordText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_EditPasswordText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_EmailText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_EmailText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_ErrorText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_ErrorText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_FacilityNotFoundText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_FacilityNotFoundText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_GenericHtmlText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_GenericHtmlText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_HtmlText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_HtmlText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_IllegalCharactersText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_IllegalCharactersText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_IntegerText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_IntegerText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_InvalidDateTimeText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_InvalidDateTimeText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_InvalidDecimalText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_InvalidDecimalText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_InvalidIntegerText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_InvalidIntegerText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_InvalidShort 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_InvalidShort"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_InvalidReasonForMissingQuantityText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_InvalidReasonForMissingQuantityText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_InvalidText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_InvalidText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_InvalidTimeSpanText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_InvalidTimeSpanText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_MaxSearchErrorMessageText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_MaxSearchErrorMessageText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_MissingQuantityText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_MissingQuantityText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_PhoneText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_PhoneText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_PostcodeText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_PostcodeText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_RequiredText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_RequiredText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_RequiredFieldText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_RequiredFieldText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_SessionTimeoutText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_SessionTimeoutText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_StringMinLengthZeroText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_StringMinLengthZeroText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_StringText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_StringText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_TabText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_TabText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_TimeText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_TimeText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_UnknownErrorText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_UnknownErrorText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_RequiredFieldsError 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_RequiredFieldsError"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string InfoMessage_LogoutText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "InfoMessage_LogoutText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Link_NotYouText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Link_NotYouText"); 
			}
		}
 
    }			
}
