using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PrintHistoryNotificationRule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PrintHistoryNotificationRuleFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PrintHistoryNotificationRule()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PrintHistoryNotificationRuleId
        /// </summary>
        public int PrintHistoryNotificationRuleId { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets NotificationRuleId
        /// </summary>
        public int NotificationRuleId { get; set; }
    
        /// <summary>
        /// Gets or sets NotificationRule
        /// </summary>
        public virtual NotificationRule NotificationRule { get; set; }
        /// <summary>
        /// Gets or sets PrintHistory
        /// </summary>
        public virtual PrintHistory PrintHistory { get; set; }
    }
}
