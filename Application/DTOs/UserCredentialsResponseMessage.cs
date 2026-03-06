using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// UserCredentialsResponseMessage
    /// </summary>
    public class UserCredentialsResponseMessage
    {
        public UserCredentialsResponseMessage(UserAuthenticationState authenticationState, UserData user, IList<UserFacilityData> UserFacility)
        {
            AuthenticationState = authenticationState;
            User = user;
            UserFacitities = UserFacility;
            
        }
        public UserCredentialsResponseMessage(UserAuthenticationState authenticationState, UserData user)
        {
            AuthenticationState = authenticationState;
            User = user;
        }
        public UserCredentialsResponseMessage(UserAuthenticationState authenticationState)
            : this(authenticationState, null, null)
        {
            AuthenticationState = authenticationState;
        }
        /// <summary>
        /// Gets or sets AuthenticationState
        /// </summary>
        public UserAuthenticationState AuthenticationState { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public UserData User { get; set; }
        /// <summary>
        /// Gets or sets UserFacitities
        /// </summary>
        public IList<UserFacilityData> UserFacitities { get; set; }
                
    }
}