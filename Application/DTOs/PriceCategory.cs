using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PriceCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PriceCategoryFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PriceCategory()
        {
            this.PriceCategoryBatchCycle = new HashSet<PriceCategoryBatchCycle>();
            this.InvoiceLine = new HashSet<InvoiceLine>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PriceCategoryId
        /// </summary>
        public int PriceCategoryId { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserId
        /// </summary>
        public Nullable<int> ArchivedUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryDefinitionId
        /// </summary>
        public int PriceCategoryDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets MaximumComponents
        /// </summary>
        public short MaximumComponents { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
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
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryDefinition
        /// </summary>
        public virtual PriceCategoryDefinition PriceCategoryDefinition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PriceCategoryBatchCycle
        /// </summary>
        public virtual ICollection<PriceCategoryBatchCycle> PriceCategoryBatchCycle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets InvoiceLine
        /// </summary>
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
    }
}
