using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable, DataContract]
    public enum ItemInstanceIdentifierTypeIdentifier : short
    {
        /// <summary>
        /// Synergy Generated Identifier
        /// </summary>
        [EnumMember]
        SynergyBarcode = 1,
        /// <summary>
        /// A Barcode (e.g. printed or laser etched)
        /// </summary>
        [EnumMember]
        Barcode = 2,
        /// <summary>
        /// An RFID tag
        /// </summary>
        [EnumMember]
        RFID = 3,
        /// <summary>
        /// A serial number
        /// </summary>
        [EnumMember]
        SerialNumber = 4
    }
}
