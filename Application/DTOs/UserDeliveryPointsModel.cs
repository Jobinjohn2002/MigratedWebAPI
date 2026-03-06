using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserDeliveryPointsModel
    /// </summary>
    public class UserDeliveryPointsModel
    {
        public UserDeliveryPointsModel()
        {
            SelectedDeliveryPoints = new List<int>();
        }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets SelectedDeliveryPoints
        /// </summary>
        public List<int> SelectedDeliveryPoints { get; set; }
    }
}