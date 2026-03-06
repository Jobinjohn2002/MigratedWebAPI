using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ScheduleFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Schedule()
        {
            this.PlannedMaintenanceRule = new HashSet<PlannedMaintenanceRule>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ScheduleId
        /// </summary>
        public int ScheduleId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets RepeatType
        /// </summary>
        public Nullable<int> RepeatType { get; set; }
        /// <summary>
        /// Gets or sets RepeatEvery
        /// </summary>
        public Nullable<int> RepeatEvery { get; set; }
        /// <summary>
        /// Gets or sets RepeatOn
        /// </summary>
        public Nullable<int> RepeatOn { get; set; }
        /// <summary>
        /// Gets or sets RepeatSkip
        /// </summary>
        public Nullable<int> RepeatSkip { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        /// <summary>
        /// Gets or sets Day
        /// </summary>
        public Nullable<int> Day { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroupId
        /// </summary>
        public Nullable<int> CustomerGroupId { get; set; }
        /// <summary>
        /// Gets or sets Uses
        /// </summary>
        public Nullable<int> Uses { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public Nullable<int> CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public Nullable<int> CustomerDefinitionId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PlannedMaintenanceRule
        /// </summary>
        public virtual ICollection<PlannedMaintenanceRule> PlannedMaintenanceRule { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinition
        /// </summary>
        public virtual CustomerDefinition CustomerDefinition { get; set; }
    }
}
