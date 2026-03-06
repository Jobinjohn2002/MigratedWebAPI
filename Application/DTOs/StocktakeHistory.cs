using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class StocktakeHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StocktakeHistoryFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public StocktakeHistory()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StocktakeHistoryId
        /// </summary>
        public int StocktakeHistoryId { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets UserID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets StocktakeActivityId
        /// </summary>
        public int StocktakeActivityId { get; set; }
    
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public virtual Location Location { get; set; }
        /// <summary>
        /// Gets or sets StocktakeActivity
        /// </summary>
        public virtual StocktakeActivity StocktakeActivity { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual Turnaround Turnaround { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
    }
}
