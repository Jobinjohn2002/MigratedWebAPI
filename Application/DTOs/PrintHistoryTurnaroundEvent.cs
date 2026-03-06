using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PrintHistoryTurnaroundEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PrintHistoryTurnaroundEventFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PrintHistoryTurnaroundEvent()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PrintHistoryTurnaroundEventId
        /// </summary>
        public int PrintHistoryTurnaroundEventId { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventId
        /// </summary>
        public int TurnaroundEventId { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets PrintHistory
        /// </summary>
        public virtual PrintHistory PrintHistory { get; set; }
    }
}
