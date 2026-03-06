using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DefectDetailsTab
    {
        Details = 0,
        Photo = 1,
        Comments = 2
    }
    public enum DefectConfirmation
    {
        None = 0,
        Success = 1,
        Archived = 2,
        Comment = 3
    }

    /// <summary>
    /// DefectDetailsModel
    /// </summary>
    public class DefectDetailsModel
    {
        /// <summary>
        /// Gets or sets Defect
        /// </summary>
        public Defect Defect { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public DefectDetailsTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public DefectConfirmation Confirmation { get; set; }
    }
}