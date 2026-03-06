using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PriceCategoryBatchCycle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PriceCategoryBatchCycleFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PriceCategoryBatchCycle()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PriceCategoryBatchCycleId
        /// </summary>
        public int PriceCategoryBatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryId
        /// </summary>
        public int PriceCategoryId { get; set; }
        /// <summary>
        /// Gets or sets Charge
        /// </summary>
        public decimal Charge { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public Nullable<int> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets BatchCycle
        /// </summary>
        public virtual BatchCycle BatchCycle { get; set; }
        /// <summary>
        /// Gets or sets PriceCategory
        /// </summary>
        public virtual PriceCategory PriceCategory { get; set; }
    }
}
