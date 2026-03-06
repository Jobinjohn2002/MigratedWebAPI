using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PrintDetailsDataContract
    /// </summary>
    public class PrintDetailsDataContract
    {
        public byte[] ByteData { get; set; }
        /// <summary>
        /// Gets or sets StringData
        /// </summary>
        public string StringData { get; set; }
        /// <summary>
        /// Gets or sets PrinterTypeId
        /// </summary>
        public int PrinterTypeId { get; set; }
        /// <summary>
        /// Gets or sets PrinterName
        /// </summary>
        public string PrinterName { get; set; }
        /// <summary>
        /// Gets or sets PrintableInstance
        /// </summary>
        public PrintableInstance PrintableInstance { get; set; }
    }
    /// <summary>
    /// PrintableInstance
    /// </summary>
    public class PrintableInstance
    {
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
    } 
}
