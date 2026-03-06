using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.Services
{		
	public static class SharedResources
	{
		private const string ResourceName = "SharedResources";

		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_AddComment 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_AddComment"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_AddCommentAndSave 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_AddCommentAndSave"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_AddDocumentText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_AddDocumentText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_AddSelectedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_AddSelectedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_AddText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_AddText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_ApplyFilterText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_ApplyFilterText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_ArchiveText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_ArchiveText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_BackText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_BackText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_BackToListText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_BackToListText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_CancelText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_CancelText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_ChangePasswordText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_ChangePasswordText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_ClickToCancelDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_ClickToCancelDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_CloseText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_CloseText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_ConfigureText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_ConfigureText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_ContinueText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_ContinueText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_DeleteText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_DeleteText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_DoneText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_DoneText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_EditText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_EditText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_EmailText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_EmailText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_LaunchTrainingText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_LaunchTrainingText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_LoginText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_LoginText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_LogoutText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_LogoutText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_NextText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_NextText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_NoText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_NoText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_NotYouText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_NotYouText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_OKText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_OKText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_OmniSearchSettings 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_OmniSearchSettings"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_PinText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_PinText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_RefreshText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_RefreshText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_RemoveText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_RemoveText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_ResetTimer 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_ResetTimer"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_SaveText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_SaveText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_SearchText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_SearchText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_SendText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_SendText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_SubmitText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_SubmitText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_UnArchiveText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_UnArchiveText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_UnlockText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_UnlockText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_UpdateText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_UpdateText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Action_YesText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Action_YesText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Button_ChangePassword_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Button_ChangePassword_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Button_Login_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Button_Login_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Button_UpdatePin_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Button_UpdatePin_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Copyright_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Copyright_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_CloseBracket 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_CloseBracket"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_ConfirmPasswordText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_ConfirmPasswordText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_ConfirmPINText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_ConfirmPINText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_EmailText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_EmailText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_headerText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_headerText"); 
			}
		}
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
		public static string Display_NewPINText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_NewPINText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_NoResultsFoundText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_NoResultsFoundText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_NotApplicableText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_NotApplicableText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_OpenBracket 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_OpenBracket"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_OperationalTimingsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_OperationalTimingsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_PlaceHolderText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_PlaceHolderText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_RemoveText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_RemoveText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SavedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SavedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SessionExpiringText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SessionExpiringText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SessionLogoutMessage 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SessionLogoutMessage"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SessionTimeoutFormatText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SessionTimeoutFormatText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_ShowingText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_ShowingText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SynergyDetailtext1 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SynergyDetailtext1"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SynergyDetailtext2 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SynergyDetailtext2"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SynergyLockedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SynergyLockedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SynergyPasswordIncorrectText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SynergyPasswordIncorrectText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SynergyRefreshText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SynergyRefreshText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_SynergyTitleText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_SynergyTitleText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_TelephoneText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_TelephoneText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Display_UnknownText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Display_UnknownText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_AccessDeniedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_AccessDeniedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_ChangePasswordUnsuccessfulText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_ChangePasswordUnsuccessfulText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_DateToText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_DateToText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_Header_AccessDeniedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_Header_AccessDeniedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_Header_FileUploadText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_Header_FileUploadText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_Message_AccessDeniedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_Message_AccessDeniedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_PasswordNotMatch 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_PasswordNotMatch"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_RecordAccessDeniedText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_RecordAccessDeniedText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ErrorMessage_SortingText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ErrorMessage_SortingText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Header_LoggedInAsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Header_LoggedInAsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Help_Email 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Help_Email"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Help_SupportDescription_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Help_SupportDescription_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Help_SupportHours_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Help_SupportHours_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Help_SupportSite 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Help_SupportSite"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string LearnMore 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "LearnMore"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Link_RememberMeText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Link_RememberMeText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Link_ShowAllText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Link_ShowAllText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_ConfirmPassword_Placeholder 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_ConfirmPassword_Placeholder"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_ConfirmPin_Placeholder 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_ConfirmPin_Placeholder"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_CurrentPassword_Placeholder 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_CurrentPassword_Placeholder"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_Display_PasswordText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_Display_PasswordText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_Display_SignIntoAccountText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_Display_SignIntoAccountText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_Display_UsernameText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_Display_UsernameText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_HelpTitle_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_HelpTitle_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_NewPassword_Placeholder 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_NewPassword_Placeholder"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_NewPin_Placeholder 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_NewPin_Placeholder"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_PageTitle 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_PageTitle"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_Password_Placeholder 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_Password_Placeholder"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_PasswordExpiredLabel_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_PasswordExpiredLabel_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_PinExpiredLabel_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_PinExpiredLabel_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_SignInLabel_Text 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_SignInLabel_Text"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Login_Username_Placeholder 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Login_Username_Placeholder"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_CustomerGroupsDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_CustomerGroupsDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_CustomerProductionSummaryText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_CustomerProductionSummaryText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_EnquiryText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_EnquiryText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_FacilityDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_FacilityDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_FastTrackRequestText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_FastTrackRequestText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_FeedbackCentreDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_FeedbackCentreDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_FinanceDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_FinanceDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_HomeDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_HomeDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ItemsDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ItemsDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_LoanSetRecordText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_LoanSetRecordText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_LocationClockingText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_LocationClockingText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_MaintenanceDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_MaintenanceDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_NewComponentText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_NewComponentText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_NewContainerText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_NewContainerText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_OrderText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_OrderText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ProductionDetailsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ProductionDetailsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ProductionDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ProductionDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ProductionManager 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ProductionManager"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ProductionOverviewText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ProductionOverviewText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ProductionCustomDetailsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ProductionCustomDetailsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ProductionSummaryText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ProductionSummaryText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_QualityDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_QualityDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_QueryIntelligenceText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_QueryIntelligenceText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ReportingDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ReportingDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_ServicesDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_ServicesDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_StockManagement 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_StockManagement"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_UsersClockingText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_UsersClockingText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_UsersDisplayText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_UsersDisplayText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Menu_UsersFindText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Menu_UsersFindText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Message_ArchiveProcedure 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Message_ArchiveProcedure"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Message_ChangePasswordSuccessfulText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Message_ChangePasswordSuccessfulText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Message_NoImagesText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Message_NoImagesText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Message_ViewImagesText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Message_ViewImagesText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Model_DateFromText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Model_DateFromText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Model_DateToText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Model_DateToText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string NoComments 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "NoComments"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Operator_Comparison_EqualToText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Operator_Comparison_EqualToText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Operator_Comparison_GreaterThanEqualToText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Operator_Comparison_GreaterThanEqualToText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Operator_Comparison_GreaterThanText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Operator_Comparison_GreaterThanText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Operator_Comparison_LessThanEqualToText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Operator_Comparison_LessThanEqualToText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Operator_Comparison_LessThanText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Operator_Comparison_LessThanText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Operator_Comparison_NotEqualToText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Operator_Comparison_NotEqualToText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerLink_AllRowsText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerLink_AllRowsText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerLink_NextText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerLink_NextText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerLink_PagingOf 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerLink_PagingOf"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerLink_PreviousText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerLink_PreviousText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerLink_RowsPerPageText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerLink_RowsPerPageText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerToolTip_GoToPageText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerToolTip_GoToPageText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerTooltip_NextPageText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerTooltip_NextPageText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string PagerTooltip_PreviousPageText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "PagerTooltip_PreviousPageText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Processing_CancelText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Processing_CancelText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Processing_LoadingText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Processing_LoadingText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Processing_WaitText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Processing_WaitText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Repeater_FilterPressEnterTitleText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Repeater_FilterPressEnterTitleText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Repeater_FilterTitleText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Repeater_FilterTitleText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Repeater_SorterTitleText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Repeater_SorterTitleText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string ServiceRequirementExistsInContainerInstanceText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "ServiceRequirementExistsInContainerInstanceText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Title_HelpText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Title_HelpText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Title_SearchInformationText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Title_SearchInformationText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string TootlTip_TrakstarLogoText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "TootlTip_TrakstarLogoText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Validation_ComparisonText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Validation_ComparisonText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Validation_MustBeSamePassword 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Validation_MustBeSamePassword"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Validation_MustBeSamePIN 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Validation_MustBeSamePIN"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Validation_PasswordCharacterRangeLengthText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Validation_PasswordCharacterRangeLengthText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Validation_PasswordLengthAndComplexityText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Validation_PasswordLengthAndComplexityText"); 
			}
		}
		/// <summary>
		///  Looks up a localized string
		/// </summary>
		public static string Validation_PasswordTypeOfCharactersText 
		{
			get
			{
				return Steris.Translation.TranslatorManager.GetText(ResourceName, "Validation_PasswordTypeOfCharactersText"); 
			}
		}
 
    }			
}
