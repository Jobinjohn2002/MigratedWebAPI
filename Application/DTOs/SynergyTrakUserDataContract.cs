using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SynergyTrakUserDataContract
    /// </summary>
    public class SynergyTrakUserDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets Pin
        /// </summary>
        public string Pin { get; set; }
        /// <summary>
        /// Gets or sets IsPinExpired
        /// </summary>
        public bool IsPinExpired { get; set; }
        /// <summary>
        /// Gets or sets IsExpired
        /// </summary>
        public bool IsExpired { get; set; }
        /// <summary>
        /// Gets or sets IsApproved
        /// </summary>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }
        /// <summary>
        /// Gets or sets IsLockedOut
        /// </summary>
        public bool IsLockedOut { get; set; }
        /// <summary>
        /// Gets or sets LastPinChange
        /// </summary>
        public DateTime LastPinChange { get; set; }
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public List<FacilityDataContract> Facilities { get; set; }
        /// <summary>
        /// Gets or sets Roles
        /// </summary>
        public List<RoleDataContract> Roles { get; set; }
        /// <summary>
        /// Gets or sets Specialities
        /// </summary>
        public List<UserSpecialityDataContract> Specialities { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormats
        /// </summary>
        public DateTimeFormatDataContract DateTimeFormats { get; set; }
        /// <summary>
        /// Gets or sets PinAttempts
        /// </summary>
        public int PinAttempts { get; set; }
        public double? PercentageIpohVariance { get; set; }
        /// <summary>
        /// Gets or sets PutAwayImmediateSubmit
        /// </summary>
        public bool PutAwayImmediateSubmit { get; set; }
        /// <summary>
        /// Gets or sets IsSoftLockedOut
        /// </summary>
        public bool IsSoftLockedOut { get; set; }
        /// <summary>
        /// Gets or sets SoftLockOutRemainingMinutes
        /// </summary>
        public int SoftLockOutRemainingMinutes { get; set; }
    }
}