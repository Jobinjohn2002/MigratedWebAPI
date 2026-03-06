using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes the various supported types of idenfifiers.
    /// </summary>
    public enum IdentifierType
    {
        /// <summary>
        /// Unknown identifier type.
        /// </summary>
        [EnumMember]
        Unknown = 0,
        /// <summary>
        /// Synery generated identifier, typically used on printed barcodes.
        /// </summary>
        [EnumMember]
        Synergy = 1,
        /// <summary>
        /// An alternative identifier, typically used as an alternative on the printed barcode to the Synergy identifier type, e.g. if the asset already has a unique identifer and the Synergy generated one is not required.
        /// </summary>
        [EnumMember]
        Alternate = 2,
        /// <summary>
        /// RFID tag.
        /// </summary>
        [EnumMember]
        RFID = 3,
        /// <summary>
        /// A manufacturers reference, such as a product number on an instrument.
        /// </summary>
        [EnumMember]
        Manufacturer = 4,
        /// <summary>
        /// The serial number a Turnaround, uniquely idenfying an asset and a single reprocessing cycle in the asset's history.
        /// </summary>
        [EnumMember]
        SerialNumber = 5
    }
}