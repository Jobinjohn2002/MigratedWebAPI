using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// BaseRequestDataContract
    /// </summary>
    public class BaseRequestDataContract
    {
        [NonSerialized]
        [IgnoreDataMember]
        private ExtensionDataObject extensionData;

        [IgnoreDataMember]
        public ExtensionDataObject ExtensionData
        {
            get { return extensionData; }
            set { extensionData = value; }
        }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        public string Hash;
        public short? PrimaryFacilityId { get; set; }
        public int? StationId { get; set; }
        /// <summary>
        /// Gets or sets NTLogon
        /// </summary>
        public string NTLogon { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets LaserPrinter
        /// </summary>
        public string LaserPrinter { get; set; }
        /// <summary>
        /// Gets or sets LabelPrinter
        /// </summary>
        public string LabelPrinter { get; set; }
        /// <summary>
        /// Gets or sets BarcodePrinter
        /// </summary>
        public string BarcodePrinter { get; set; }
        /// <summary>
        /// Gets or sets IsNetworkPrinting
        /// </summary>
        public bool IsNetworkPrinting { get; set; }
    }
}