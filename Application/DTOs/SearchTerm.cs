using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SearchTerm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SearchTermFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SearchTerm()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SearchTermId
        /// </summary>
        public long SearchTermId { get; set; }
        /// <summary>
        /// Gets or sets ObjectTypeId
        /// </summary>
        public byte ObjectTypeId { get; set; }
        /// <summary>
        /// Gets or sets ObjectId
        /// </summary>
        public Nullable<int> ObjectId { get; set; }
        public Nullable<System.Guid> ObjectUid { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    
        /// <summary>
        /// Gets or sets ObjectType
        /// </summary>
        public virtual ObjectType ObjectType { get; set; }
    }
}
