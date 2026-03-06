using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes a Delivery Note, including items on the delivery note.
    /// </summary>
    /// <summary>
    /// DeliveryNoteInfo
    /// </summary>
    public class DeliveryNoteInfo
    {
        /// <summary>
        /// The unique delivery number, typically located in the lower left corner of the delivery note.
        /// </summary>
        /// <summary>
        /// Gets or sets DeliveryNoteNumber
        /// </summary>
        public int DeliveryNoteNumber { get; set; }
        /// <summary>
        /// The sterile services dapartment that dispatched the items on the delivery note.
        /// </summary>
        /// <summary>
        /// Gets or sets Sender
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// The recipient of the items on the delivery note.
        /// </summary>
        /// <summary>
        /// Gets or sets Recipient
        /// </summary>
        public LocationInfo Recipient { get; set; }
        /// <summary>
        /// The turnarounds describing the assets delivered, their specification and any exceptions.
        /// </summary>
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public List<TurnaroundSpecificationInfo> Turnarounds { get; set; }
    }
}
