using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class RetrospectiveEventWhiteList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use RetrospectiveEventWhiteListFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public RetrospectiveEventWhiteList()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets RetrospectiveEventWhiteListID
        /// </summary>
        public int RetrospectiveEventWhiteListID { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public short EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
    
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public virtual EventType EventType { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual ItemType ItemType { get; set; }
    }
}
