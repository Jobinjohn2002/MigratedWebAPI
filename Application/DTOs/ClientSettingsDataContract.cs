using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ClientSettingsDataContract
    /// </summary>
    public class ClientSettingsDataContract : BaseReplyDataContract
    {
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets XML
        /// </summary>
        public string XML { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        public int? StationId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets StationCategory
        /// </summary>
        public StationTypeCategoryIdentifier StationCategory { get; set; }
        /// <summary>
        /// Gets or sets StationLocationId
        /// </summary>
        public int StationLocationId { get; set; }
        /// <summary>
        /// Gets or sets NTLogon
        /// </summary>
        public string NTLogon { get; set; }
        /// <summary>
        /// Gets or sets MachineIds
        /// </summary>
        public List<int> MachineIds { get; set; }
        /// <summary>
        /// Gets or sets AssociatedStationTypes
        /// </summary>
        public List<AssociatedStation> AssociatedStationTypes { get; set; }
        /// <summary>
        /// Gets or sets LaserPrinterConfig
        /// </summary>
        public PrinterDataContract LaserPrinterConfig { get; set; }
        /// <summary>
        /// Gets or sets LabelPrinterConfig
        /// </summary>
        public PrinterDataContract LabelPrinterConfig { get; set; }
        /// <summary>
        /// Gets or sets BarcodePrinterConfig
        /// </summary>
        public PrinterDataContract BarcodePrinterConfig { get; set; }
        /// <summary>
        /// Gets or sets ShowPrioritisation
        /// </summary>
        public bool ShowPrioritisation { get; set; }
        /// <summary>
        /// Gets or sets CameraDevice
        /// </summary>
        public CameraDeviceDataContract CameraDevice { get; set; }
    }
}