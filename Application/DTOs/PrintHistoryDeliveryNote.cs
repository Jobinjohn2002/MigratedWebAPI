using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PrintHistoryDeliveryNote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PrintHistoryDeliveryNoteFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PrintHistoryDeliveryNote()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PrintHistoryDeliveryNoteId
        /// </summary>
        public int PrintHistoryDeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public int DeliveryNoteId { get; set; }
    
        /// <summary>
        /// Gets or sets DeliveryNote
        /// </summary>
        public virtual DeliveryNote DeliveryNote { get; set; }
        /// <summary>
        /// Gets or sets PrintHistory
        /// </summary>
        public virtual PrintHistory PrintHistory { get; set; }
    }
}
