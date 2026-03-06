using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// NoteDataContract
    /// </summary>
    public class NoteDataContract : BaseReplyDataContract
    {
        public int? TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Gets or sets StationTypes
        /// </summary>
        public List<NoteStationTypeDataContract> StationTypes { get; set; }
        public TertiaryActivity? Activity { get; set; }
        /// <summary>
        /// Gets or sets ProcessNoteType
        /// </summary>
        public ProcessNoteType ProcessNoteType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ArchivedDate { get; set; }
        public DateTime? ActiveFrom { get; set; }
        /// <summary>
        /// Gets or sets CreatedById
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// Gets or sets CreatedByName
        /// </summary>
        public string CreatedByName { get; set; }
    }
}