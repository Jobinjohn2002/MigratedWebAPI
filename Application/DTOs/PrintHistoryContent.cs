using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PrintHistoryContent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PrintHistoryContentFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PrintHistoryContent()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PrintHistoryContentId
        /// </summary>
        public int PrintHistoryContentId { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets PrinterTypeId
        /// </summary>
        public byte PrinterTypeId { get; set; }
        public System.Guid ContentId { get; set; }
        public System.DateTime Ordinal { get; set; }
    
        /// <summary>
        /// Gets or sets PrinterType
        /// </summary>
        public virtual PrinterType PrinterType { get; set; }
        /// <summary>
        /// Gets or sets PrintHistory
        /// </summary>
        public virtual PrintHistory PrintHistory { get; set; }
    }
}
