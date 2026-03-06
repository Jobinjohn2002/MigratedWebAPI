using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ItemEstimatedTimeOfArrival
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ItemEstimatedTimeOfArrivalFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ItemEstimatedTimeOfArrival()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ItemEstimatedTimeOfArrivalId
        /// </summary>
        public int ItemEstimatedTimeOfArrivalId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        public System.DateTime EstimatedTimeOfArrival { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual Turnaround Turnaround { get; set; }
    }
}
