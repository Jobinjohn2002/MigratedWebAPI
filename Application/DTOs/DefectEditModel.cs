using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DefectDetailsConfirmation
    {
        None = 0,
        Created = 1,
        Updated = 2,
        Commented = 3,
        ImmediateAction = 4,
        LongTermAction = 5,
        ReviewAction = 6
    }

    /// <summary>
    /// DefectEditModel
    /// </summary>
    public class DefectEditModel : DefectModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public DefectDetailsConfirmation Confirmation { get; set; }

        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public IEnumerable<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets DefectId
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public string Facility { get; set; }

        /// <summary>
        /// Gets or sets HasPhoto
        /// </summary>
        public bool HasPhoto { get; set; }

        /// <summary>
        /// Gets or sets History
        /// </summary>
        public IEnumerable<DefectAuditHistory> History { get; set; }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }

        [SmartPropertyValidation]
        public byte? StatusId { get; set; }

        /// <summary>
        /// Gets or sets Statuses
        /// </summary>
        public IEnumerable<SelectListItem> Statuses { get; set; }

        public int? UnTrackedProductId { get; set; }

        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public IEnumerable<GroupedListItem> Users { get; set; }

        /// <summary>
        /// Gets or sets ImmediateAction
        /// </summary>
        public DefectActionModel ImmediateAction { get; set; }

        /// <summary>
        /// Gets or sets LongTermAction
        /// </summary>
        public DefectActionModel LongTermAction { get; set; }

        /// <summary>
        /// Gets or sets ReviewAction
        /// </summary>
        public DefectActionModel ReviewAction { get; set; }

        /// <summary>
        /// Gets or sets CloseOut
        /// </summary>
        public DefectCloseOutModel CloseOut { get; set; }

        /// <summary>
        /// Gets or sets Defect
        /// </summary>
        public Defect Defect { get; set; }

        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public Turnaround Turnaround { get; set; }
    }
}