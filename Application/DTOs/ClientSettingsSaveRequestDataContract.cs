using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ClientSettingsSaveRequestDataContract
    /// </summary>
    public class ClientSettingsSaveRequestDataContract : BaseRequestDataContract
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
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets StationLocationId
        /// </summary>
        public int StationLocationId { get; set; }
        /// <summary>
        /// Gets or sets NewNTLogon
        /// </summary>
        public string NewNTLogon { get; set; }
        /// <summary>
        /// Gets or sets MachineIds
        /// </summary>
        public List<int> MachineIds { get; set; }
        /// <summary>
        /// Gets or sets AssociatedStationTypes
        /// </summary>
        public List<AssociatedStation> AssociatedStationTypes { get; set; }
        /// <summary>
        /// Gets or sets IsNetworkPrinters
        /// </summary>
        public bool IsNetworkPrinters { get; set; }
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
        /// Gets or sets CameraDevice
        /// </summary>
        public CameraDeviceDataContract CameraDevice { get; set; }
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public List<SettingDataContract> Settings { get; set; }
    }
}