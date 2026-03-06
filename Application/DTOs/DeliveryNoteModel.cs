using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DeliveryNoteTab
    {
        Details = 0,
        Turnaround = 1
    }

    /// <summary>
    /// DeliveryNoteModel
    /// </summary>
    public class DeliveryNoteModel
    {
        /// <summary>
        /// Gets or sets DeliveryNote
        /// </summary>
        public DeliveryNote DeliveryNote { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public DeliveryNoteTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets PrintedByFullname
        /// </summary>
        public string PrintedByFullname { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public List<DeliveryPoint> DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public List<User> User { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public List<Turnaround> Turnaround { get; set; }

        public int TurnaroundCount => Turnaround?.Count ?? 0;
    }
}