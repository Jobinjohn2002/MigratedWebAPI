using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserModel
    /// </summary>
    public class UserModel
    {
        public UserModel()
        {
            Details = new UserDetailsModel();
            Printers = new UserPrintersModel();
            DeliveryPoints = new UserDeliveryPointsModel();
            Locale = new UserLocaleModel();
            Roles = new UserRolesModel();
        }

        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public UserDetailsModel Details { get; set; }
        /// <summary>
        /// Gets or sets Printers
        /// </summary>
        public UserPrintersModel Printers { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public UserDeliveryPointsModel DeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets Locale
        /// </summary>
        public UserLocaleModel Locale { get; set; }
        /// <summary>
        /// Gets or sets Roles
        /// </summary>
        public UserRolesModel Roles { get; set; }
    }
}