using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class UserData
    {
        public UserData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userFacilities">The user facilities.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="userPermissions">The user permissions.</param>
        /// <param name="userPrinters">The user printers.</param>
        /// <remarks></remarks>
        public UserData(IUser user,
                        IList<UserFacilityData> userFacilities,
                        IList<RoleData> roles,
                        IList<UserPrinterData> userPrinters,
                        IList<UserComplexityData> userItemComplexities)
            : this(user)
        {
            UserFacilities = userFacilities;
            Roles = roles;
            UserPrinters = userPrinters;
        }

		public UserData(IUser user,
						IList<RoleData> roles,
						IList<RolePermissionData> rolePermissions)
			: this(user)
		{
			Roles = roles;
			RolePermissions = rolePermissions;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="facilities">The facilities.</param>
        /// <remarks></remarks>
        public UserData(IUser user,
                        IList<short> facilities)
            : this(user)
        {
            AssignedFacilityIds = facilities;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="facilities">The facilities.</param>
        /// <param name="roleData">The role data.</param>
        /// <remarks></remarks>
        public UserData(IUser user,
                        IList<short> facilities, IEnumerable<RoleData> roleData)
            : this(user)
        {
            AssignedFacilityIds = facilities;
            Roles = roleData;
        }

        /// <summary>
        /// Gets or sets the user facilities.
        /// </summary>
        /// <value>The user facilities.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets UserFacilities
        /// </summary>
        public IEnumerable<UserFacilityData> UserFacilities { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Roles
        /// </summary>
        public IEnumerable<RoleData> Roles { get; set; }

        /// <summary>
        /// Gets or sets the permissions.
        /// </summary>
        /// <value>The permissions.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Permissions
        /// </summary>
        public IEnumerable<PermissionData> Permissions { get; set; }
		/// <summary>
		/// Gets or sets RolePermissions
		/// </summary>
		public IList<RolePermissionData> RolePermissions { get; set; }
        /// <summary>
        /// Gets or sets UserReports
        /// </summary>
        public IList<UserReportData> UserReports { get; set; }

        /// <summary>
        /// Gets or sets the user printers.
        /// </summary>
        /// <value>The user printers.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets UserPrinters
        /// </summary>
        public IList<UserPrinterData> UserPrinters { get; set; }

        
        /// <summary>
        /// Gets or sets the assigned facility ids.
        /// </summary>
        /// <value>The assigned facility ids.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AssignedFacilityIds
        /// </summary>
        public IList<short> AssignedFacilityIds { get; set; }
		/// <summary>
		/// Gets or sets UserComplexity
		/// </summary>
		public IList<UserComplexityData> UserComplexity { get; set; }

        /// <summary>
        /// Gets or sets the Customer Gtin
        /// </summary>
        /// <value>The Customer Gtin.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Total
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// The state of the login attempt
        /// </summary>
        /// <summary>
        /// Gets or sets LoginResult
        /// </summary>
        public AccountAuthenticationResult LoginResult { get; set; }

        /// <summary>
        /// Gets or sets the primary facility Id 
        /// </summary>
        /// <value>The primary facility Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets PrimaryFacilityId
        /// </summary>
        public int PrimaryFacilityId { get; set; }

        /// <summary>
        /// Gets or sets the Tenancy Setting.
        /// </summary>
        /// <value>The Tenancy Setting.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TenancySetting
        /// </summary>
        public IEnumerable<TenancySettingData> TenancySetting { get; set; }
        /// <summary>
        /// Gets or sets LongTimeFormatId
        /// </summary>
        public int LongTimeFormatId { get; set; }
        /// <summary>
        /// Gets or sets LongDateFormatId
        /// </summary>
        public int LongDateFormatId { get; set; }
        /// <summary>
        /// Gets or sets ShortDateFormatId
        /// </summary>
        public int ShortDateFormatId { get; set; }
        /// <summary>
        /// Gets or sets ShortTimeFormatId
        /// </summary>
        public int ShortTimeFormatId { get; set; }
        /// <summary>
        /// Gets or sets LongTimeFormat
        /// </summary>
        public string LongTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets LongDateFormat
        /// </summary>
        public string LongDateFormat { get; set; }
        /// <summary>
        /// Gets or sets ShortDateFormat
        /// </summary>
        public string ShortDateFormat { get; set; }
        /// <summary>
        /// Gets or sets ShortTimeFormat
        /// </summary>
        public string ShortTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets TimeZone
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// Gets or sets TzdbZone
        /// </summary>
        public string TzdbZone { get; set; }
        /// <summary>
        /// Gets or sets SoftLockOutRemainingMinutes
        /// </summary>
        public int SoftLockOutRemainingMinutes { get; set; }
        /// <summary>
        /// Gets or sets UnusablePreviousPasswords
        /// </summary>
        public int UnusablePreviousPasswords { get; set; }
    }
}