using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum FastTrackDetailsTab
    {
        Details = 0,
        Comments = 1
    }

    public enum FastTrackStatus
    {
        New = 1,
        UnderReview = 2,
        Rejected = 4,
        Archived = 5
    }

    public enum FastTrackConfirmation
    {
        None = 0,
        Success = 1,
        Archived = 2,
        Comment = 3
    }

    /// <summary>
    /// FastTrackDetailsLineModel
    /// </summary>
    public class FastTrackDetailsLineModel
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets IsInstance
        /// </summary>
        public bool IsInstance { get; set; }
        public int? ContainerMasterId { get; set; }
        public int? ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets AssociatedTurnarounds
        /// </summary>
        public List<FastTrackDetailsAssociatedTurnaroundModel> AssociatedTurnarounds { get; set; }
    }

    /// <summary>
    /// FastTrackDetailsAssociatedTurnaroundModel
    /// </summary>
    public class FastTrackDetailsAssociatedTurnaroundModel
    {
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
    }

    /// <summary>
    /// FastTrackDetailsModel
    /// </summary>
    public class FastTrackDetailsModel
    {
        /// <summary>
        /// Gets or sets FastTrack
        /// </summary>
        public FastTrackRequest FastTrack { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public FastTrackDetailsTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public FastTrackConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets Archived
        /// </summary>
        public bool Archived { get; set; }
        /// <summary>
        /// Gets or sets FastTrackDetailsLines
        /// </summary>
        public List<FastTrackDetailsLineModel> FastTrackDetailsLines { get; set; } = new List<FastTrackDetailsLineModel>();
    }
}