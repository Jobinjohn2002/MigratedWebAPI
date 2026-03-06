using System;
using System.Linq;
using Task = System.Threading.Tasks.Task;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Hospital Authentication Filter Attribute
    /// </summary>
    /// <summary>
    /// SynergyTrakAuthenticationAttribute
    /// </summary>
    public class SynergyTrakAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        internal static class Constants
        {
            internal const string RequestScheme = "https";
            internal const char SplitCharacter = ':';

            internal static class Messages
            {
                internal const string AuthenticationHeaderMissing = "Authorisation parameter missing from headers";
                internal const string AuthenticationSchemeNotSupported = "Authorisation scheme {0} not supported";
                internal const string AuthenticationHeaderFormatInvalid = "Authorisation header format invalid";
                internal const string AuthenticationFailed = "Authentication failed credentials invalid";
                internal const string AccessDenied = "Credentials do not grant permission to the requested resource";
                internal const string NonHttpsCommunication = "Request refused, communication must be established over https";
            }
        }

        public SynergyTrakAuthenticationAttribute(PermissionCheck check = PermissionCheck.RequireAll)
        {
            Check = check;
        }

        /// <summary>
        /// Get/Set the permissions required by the current user to authenticate for this controller or action.
        /// </summary>
        public KnownPermission[] Permissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Check
        /// </summary>
        public PermissionCheck Check { get; set; }

        /// <summary>
        /// Authenticates the request.
        /// </summary>
        /// <param name="context">The authentication context.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation.</param>
        /// <returns>A task that will perform authentication.</returns>
        /// <summary>
        /// AuthenticateAsync operation
        /// </summary>
        public async Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                var request = context.Request;
                var controller = context.ActionContext.ControllerContext.Controller as ApiBaseController;

                if (controller == null)
                    throw new InvalidCastException($"SynergyTrakAuthenticationAttribute should only be used on actions for controllers that inherit from CustomerApiController{nameof(ApiBaseController)}");
                if (!Debugger.IsAttached && request.RequestUri.Scheme.ToLower() != Constants.RequestScheme)
                {
                    controller.Log("Authorisation rejected, non-HTTPS request", LogLevel.Warning);

                    context.ErrorResult = new AuthenticationFailureResult
                    {
                        Reason = Constants.Messages.NonHttpsCommunication,
                        Request = request,
                        StatusCode = HttpStatusCode.Forbidden
                    };

                    return;
                }
                

                var headers = request.Headers;

                var authorisation = headers.Authorization;
                if (string.IsNullOrEmpty(authorisation?.Parameter))
                {
                    controller.Log("Authorisation header missing from API Request", LogLevel.Warning);

                    context.ErrorResult = new AuthenticationFailureResult
                    {
                        Reason = Constants.Messages.AuthenticationHeaderMissing,
                        Request = request
                    };

                    return;
                }
                if (string.IsNullOrEmpty(authorisation.Scheme) || !String.Equals(authorisation.Scheme, BasicChallengeResult.AuthenticationScheme, StringComparison.CurrentCultureIgnoreCase))
                {
                    controller.Log("Authorisation Scheme invalid, {0} received, {1} required".FormatWith(authorisation.Scheme, BasicChallengeResult.AuthenticationScheme), LogLevel.Warning);

                    context.ErrorResult = new AuthenticationFailureResult
                    {
                        Reason = Constants.Messages.AuthenticationSchemeNotSupported.FormatWith(authorisation.Scheme),
                        Request = request
                    };

                    return;
                }
                var credentials = ExtractCredentials(authorisation.Parameter);
                if (credentials == null)
                {

                    controller.Log("Authentication Credentials could not be extracted from Header", LogLevel.Warning);

                    context.ErrorResult = new AuthenticationFailureResult
                    {
                        Reason = Constants.Messages.AuthenticationHeaderFormatInvalid,
                        Request = request
                    };

                    return;
                }

                using (var accounts = InstanceFactory.GetInstance<IAccountService>())
                {
                    User user;
                    var result = accounts.Authenticate(credentials.AuthID, credentials.AuthPwd, out user, request);

                    if (user != null && result.HasFlag(AccountAuthenticationResult.Authentic))
                    {
                        if (Permissions != null && Permissions.Any())
                        {
                            var permissions = Permissions.Select(kp => (int)kp).ToArray();

                            if ((Check == PermissionCheck.RequireAll && !user.HasPermission(permissions)) ||
                                (Check == PermissionCheck.RequireAny && !user.HasAnyPermission(permissions)))
                            {
                                controller.Log("Authorisation failed for {0}, insufficient permissions to call required API, permissions required: {0}".FormatWith(string.Join(",", permissions)), LogLevel.Warning);

                                context.ErrorResult = new AuthenticationFailureResult
                                {
                                    Reason = Constants.Messages.AccessDenied,
                                    Request = request
                                };

                                return;
                            }
                        }

                        if (controller != null)
                        {
                            controller.SynergyUser = user;
                            controller.Log("Authorisation success for {0}".FormatWith(user.UserName));
                        }

                        return;
                    }
                    
                }

                controller.Log("Authorisation failed for {0}, invalid username or password".FormatWith(credentials.AuthID), LogLevel.Warning);
                context.ErrorResult = new AuthenticationFailureResult
                {
                    Reason = Constants.Messages.AuthenticationFailed,
                    Request = request
                };
            }, cancellationToken);
        }

        /// <summary>
        /// Sends an authentication challenge response if authentication parameters we're not provided.
        /// </summary>
        /// <param name="context">The authentication context.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation.</param>
        /// <returns>A task that will perform the challenge.</returns>
        /// <summary>
        /// ChallengeAsync operation
        /// </summary>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            context.Result = new BasicChallengeResult(context.Result);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Gets a value indicating if more than one instance of this attribute can be applied to a controller or action.
        /// </summary>
        public bool AllowMultiple
        {
            get { return false; }
        }

        private static Credentials ExtractCredentials(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                return null;

            try
            {
                var bytes = Convert.FromBase64String(parameter);

                var value = Encoding.UTF8.GetString(bytes);
                var splitIndex = value.IndexOf(Constants.SplitCharacter);

                if (splitIndex < 1)
                    return null;
                return new Credentials
                {
                    AuthID = value.Substring(0, splitIndex),
                    AuthPwd = value.Substring(splitIndex + 1)
                };
            }
            catch
            {
                return null;
            }
        }
    }
}