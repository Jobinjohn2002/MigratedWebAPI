using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    [Flags]
    public enum AccountAuthenticationResult : byte
    {
        Unknown = 0,
        Invalid = 1,
        AccessDenied = 2,
        PasswordExpired = 4,
        PinExpired = 8,
        NoFacilities = 16,
        TooManyAttempts = 32,
        InsufficientPermission = 64,
        Authentic = 128
    }

    /// <summary>
    /// IAccountService
    /// </summary>
    public interface IAccountService : IServiceBase
    {
        string LanguageCookieName { get; }
        AccountAuthenticationResult Authenticate(string username, string password, out User user, HttpRequestMessage request = null, IPathwayRepository repository = null, string browserAgent = "", string ipAddress = "");
        AccountAuthenticationResult Authenticate(int userID, out User user, IPathwayRepository repository = null, HttpRequestMessage request = null);
        User RetrieveUser(IPathwayRepository repository = null);
        User RetrieveUser(string username, IPathwayRepository repository = null);
        User RetrieveCurrentUser(HttpContextBase context, IPathwayRepository repository = null);
        void WriteAuthentiationCookie(HttpContextBase context, User user, bool rememberMe);
        void SetUserOnContext(HttpContextBase context, IPathwayRepository repository = null);
        void WriteCultureToCookie(HttpContextBase httpContextBase, int cultureId);
        void UpdateUserCulture(int userId, int cultureId);
        CultureInfo ReadCultureFromCookie(HttpContextBase context);
        bool SwitchTenancy(int user, int newTenancyId, IPathwayRepository repository = null);
    }
}
