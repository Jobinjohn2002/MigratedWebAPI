using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DefectCloseOutConfirmation
    {
        None = 0,
        Updated = 1
    }

    /// <summary>
    /// DefectCloseOutModel
    /// </summary>
    public class DefectCloseOutModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public DefectCloseOutConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets DefectId
        /// </summary>
        public int DefectId { get; set; }
        [SmartPropertyValidation]
        public int? UserId { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public IEnumerable<SelectListItem> Users { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets TrustSignee
        /// </summary>
        public string TrustSignee { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
    }
}