using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{		
	public static class Finance_CommonResources
	{
		private const string ResourceName = "Finance_CommonResources";

		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_BaseAndCurrentPrice 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_BaseAndCurrentPrice"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_BasePrice 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_BasePrice"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_CurrentPrice 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_CurrentPrice"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_LoggedInAsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_LoggedInAsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_MailDeliverableItemsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_MailDeliverableItemsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_MailSingleUseComponents 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_MailSingleUseComponents"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_PageNotFoundText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_PageNotFoundText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_PrintDeliverableItemsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_PrintDeliverableItemsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_PrintSingleUseComponents 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_PrintSingleUseComponents"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SelectedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SelectedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_WelcomeToTrakStarText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_WelcomeToTrakStarText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Error_DefaultText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Error_DefaultText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Header_ApplicationText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Header_ApplicationText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Header_ApplicationTitleText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Header_ApplicationTitleText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Header_MailDeliverableItemsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Header_MailDeliverableItemsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Header_MailSingleUseComponentText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Header_MailSingleUseComponentText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Header_PrintDeliverableitemsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Header_PrintDeliverableitemsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Header_PrintSingleUseComponentText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Header_PrintSingleUseComponentText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_CustomerCentreText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_CustomerCentreText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_HomeText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_HomeText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_InvoicesSchedulingText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_InvoicesSchedulingText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_InvoicingCentreText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_InvoicingCentreText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ReportsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ReportsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ViewbyCustomerGroupText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ViewbyCustomerGroupText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ViewbyCustomerLocationGroupsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ViewbyCustomerLocationGroupsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ViewbyFacilityText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ViewbyFacilityText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Message_EmailSingleUseComponentsSucessText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Message_EmailSingleUseComponentsSucessText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Message_PrintDeliverableItemsSucessText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Message_PrintDeliverableItemsSucessText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Message_PrintSingleUseCOmponentsSucessText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Message_PrintSingleUseCOmponentsSucessText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Title_DeliverableItemsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Title_DeliverableItemsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Title_ErrorText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Title_ErrorText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Title_PriceCategoryText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Title_PriceCategoryText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Title_SingleuseComponentsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Title_SingleuseComponentsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Warning_SearchMinLengthText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Warning_SearchMinLengthText"); 
			}
		}
 
    }			
}
