using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserDetailsModel
    /// </summary>
    public class UserDetailsModel
    {
        public UserDetailsModel()
        {
            UserCategories = new List<UserCategory>();
            CustomerGroups = new List<CustomerGroup>();
        }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets Firstname
        /// </summary>
        public string Firstname { get; set; }
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Gets or sets EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// Gets or sets Protected
        /// </summary>
        public bool Protected { get; set; }
        /// <summary>
        /// Gets or sets LockedOut
        /// </summary>
        public bool LockedOut { get; set; }
        /// <summary>
        /// Gets or sets IndependentQACheck
        /// </summary>
        public bool IndependentQACheck { get; set; }
        /// <summary>
        /// Gets or sets Expired
        /// </summary>
        public bool Expired { get; set; }
        public int? CategoryId { get; set; }
        public int? CustomerGroupId { get; set; }

        public string Fullname
        {
            get { return "{0} {1}".FormatWith(Firstname, Surname).Trim(); }
        }

        /// <summary>
        /// Gets or sets UserCategories
        /// </summary>
        public List<UserCategory> UserCategories { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroups
        /// </summary>
        public List<CustomerGroup> CustomerGroups { get; set; }

    }
}