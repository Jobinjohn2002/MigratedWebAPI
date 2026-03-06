using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PrintHistoryBatch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PrintHistoryBatchFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PrintHistoryBatch()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PrintHistoryBatchId
        /// </summary>
        public int PrintHistoryBatchId { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
    
        /// <summary>
        /// Gets or sets Batch
        /// </summary>
        public virtual Batch Batch { get; set; }
        /// <summary>
        /// Gets or sets PrintHistory
        /// </summary>
        public virtual PrintHistory PrintHistory { get; set; }
    }
}
