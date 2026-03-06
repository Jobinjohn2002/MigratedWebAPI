using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PriceCategoryGroupItemType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PriceCategoryGroupItemTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PriceCategoryGroupItemType()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PriceCategoryGroupItemTypeId
        /// </summary>
        public int PriceCategoryGroupItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroupId
        /// </summary>
        public int PriceCategoryGroupId { get; set; }
    
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual ItemType ItemType { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroup
        /// </summary>
        public virtual PriceCategoryGroup PriceCategoryGroup { get; set; }
    }
}
