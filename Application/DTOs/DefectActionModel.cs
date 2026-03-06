using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DefectActionConfirmation
    {
        None = 0,
        Updated = 1
    }

    /// <summary>
    /// DefectActionModel
    /// </summary>
    public class DefectActionModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public DefectActionConfirmation Confirmation { get; set; }

        /// <summary>
        /// Gets or sets DefectId
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// Gets or sets FormAction
        /// </summary>
        public string FormAction { get; set; }

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

        [SmartPropertyValidation]
        [DateOnly(AssumeDateOnlyTimeComponent.AssumeUtcMidday)]
        public DateTime? Date { get; set; }

        [SmartPropertyValidation]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public IEnumerable<GroupedListItem> Users { get; set; }

        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets ContainerID
        /// </summary>
        public string ContainerID { get; set; }
    }
}