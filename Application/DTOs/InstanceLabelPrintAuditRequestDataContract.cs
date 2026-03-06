using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InstanceLabelPrintAuditRequestDataContract
    /// </summary>
    public class InstanceLabelPrintAuditRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        public int? OneDLabelType { get; set; }
        public int? TwoDLabelType { get; set; }
        /// <summary>
        /// Gets or sets LabelFormat
        /// </summary>
        public PrintTypeIdentifier LabelFormat { get; set; }
        /// <summary>
        /// Gets or sets IsReprint
        /// </summary>
        public bool IsReprint { get; set; }
    }
}
