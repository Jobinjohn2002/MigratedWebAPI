using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProfileModel
    /// </summary>
    public class ProfileModel
    {
        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public UserDetails Details { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public IList<DeliveryPoint> DeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets Roles
        /// </summary>
        public IList<Role> Roles { get; set; }
    }

    /// <summary>
    /// UserDetails
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public HttpStatusCode Result { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string Email { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Firstname
        /// </summary>
        public string Firstname { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public string Position { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        public string Telephone { get; set; }
    }
}