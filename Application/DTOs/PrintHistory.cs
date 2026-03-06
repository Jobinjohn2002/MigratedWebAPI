using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PrintHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PrintHistoryFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PrintHistory()
        {
            this.PrintHistoryBatch = new HashSet<PrintHistoryBatch>();
            this.PrintHistoryContent = new HashSet<PrintHistoryContent>();
            this.PrintHistoryDeliveryNote = new HashSet<PrintHistoryDeliveryNote>();
            this.PrintHistoryNotificationRule = new HashSet<PrintHistoryNotificationRule>();
            this.PrintHistoryTurnaround = new HashSet<PrintHistoryTurnaround>();
            this.PrintHistoryTurnaroundEvent = new HashSet<PrintHistoryTurnaroundEvent>();
            this.TurnaroundEventReprint = new HashSet<TurnaroundEventReprint>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets PrintedByUserId
        /// </summary>
        public int PrintedByUserId { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets PrintContentTypeId
        /// </summary>
        public int PrintContentTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContentRemoved
        /// </summary>
        public bool ContentRemoved { get; set; }
    
        /// <summary>
        /// Gets or sets PrintContentType
        /// </summary>
        public virtual PrintContentType PrintContentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PrintHistoryBatch
        /// </summary>
        public virtual ICollection<PrintHistoryBatch> PrintHistoryBatch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PrintHistoryContent
        /// </summary>
        public virtual ICollection<PrintHistoryContent> PrintHistoryContent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PrintHistoryDeliveryNote
        /// </summary>
        public virtual ICollection<PrintHistoryDeliveryNote> PrintHistoryDeliveryNote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PrintHistoryNotificationRule
        /// </summary>
        public virtual ICollection<PrintHistoryNotificationRule> PrintHistoryNotificationRule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PrintHistoryTurnaround
        /// </summary>
        public virtual ICollection<PrintHistoryTurnaround> PrintHistoryTurnaround { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PrintHistoryTurnaroundEvent
        /// </summary>
        public virtual ICollection<PrintHistoryTurnaroundEvent> PrintHistoryTurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEventReprint
        /// </summary>
        public virtual ICollection<TurnaroundEventReprint> TurnaroundEventReprint { get; set; }
    }
}
