using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ChangeControlDetailsTab
    {
        Details = 0,
        Comments = 1
    }
    public enum ChangeControlConfirmation
    {
        None = 0,
        Success = 1,
        Archived = 2,
        Comment = 3,
        New = 4
    }

    /// <summary>
    /// ChangeControlDetailsModel
    /// </summary>
    public class ChangeControlDetailsModel
    {
        /// <summary>
        /// Gets or sets ChangeRequest
        /// </summary>
        public ChangeControlNote ChangeRequest { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public ChangeControlDetailsTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets ShowSuccessConfirmation
        /// </summary>
        public bool ShowSuccessConfirmation { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public ChangeControlConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets ChangeControlNoteStatuses
        /// </summary>
        public IEnumerable<SelectListItem> ChangeControlNoteStatuses { get; set; }
    }
}