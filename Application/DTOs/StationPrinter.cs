using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class StationPrinter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StationPrinterFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public StationPrinter()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StationPrinterId
        /// </summary>
        public int StationPrinterId { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
        /// <summary>
        /// Gets or sets PrinterId
        /// </summary>
        public int PrinterId { get; set; }
        /// <summary>
        /// Gets or sets PrinterTypeId
        /// </summary>
        public byte PrinterTypeId { get; set; }
    
        /// <summary>
        /// Gets or sets Printer
        /// </summary>
        public virtual Printer Printer { get; set; }
        /// <summary>
        /// Gets or sets PrinterType
        /// </summary>
        public virtual PrinterType PrinterType { get; set; }
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual Station Station { get; set; }
    }
}
