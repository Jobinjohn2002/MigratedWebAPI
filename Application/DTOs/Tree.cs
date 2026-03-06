using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Tree
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TreeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Tree()
        {
            this.Leaf = new HashSet<Leaf>();
            this.LocationTree = new HashSet<LocationTree>();
            this.Machine = new HashSet<Machine>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TreeId
        /// </summary>
        public int TreeId { get; set; }
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public Nullable<int> OwnerId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Leaf
        /// </summary>
        public virtual ICollection<Leaf> Leaf { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets LocationTree
        /// </summary>
        public virtual ICollection<LocationTree> LocationTree { get; set; }
        /// <summary>
        /// Gets or sets Owner
        /// </summary>
        public virtual Owner Owner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Machine
        /// </summary>
        public virtual ICollection<Machine> Machine { get; set; }
    }
}
