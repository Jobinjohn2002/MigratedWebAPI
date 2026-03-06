using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CameraDeviceDataContract
    /// </summary>
    public class CameraDeviceDataContract
    {
        /// <summary>
        /// Gets or sets CameraName
        /// </summary>
        public string CameraName { get; set; }
        /// <summary>
        /// Gets or sets CameraMoniker
        /// </summary>
        public string CameraMoniker { get; set; }
    }
}
