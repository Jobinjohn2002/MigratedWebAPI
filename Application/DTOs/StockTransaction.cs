using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class StockTransaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StockTransactionFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public StockTransaction()
        {
            this.StockMovement = new HashSet<StockMovement>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StockTransactionId
        /// </summary>
        public int StockTransactionId { get; set; }
        /// <summary>
        /// Gets or sets StockTransactionTypeId
        /// </summary>
        public byte StockTransactionTypeId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets ReferenceNo
        /// </summary>
        public string ReferenceNo { get; set; }
        public System.DateTime Created { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StockMovement
        /// </summary>
        public virtual ICollection<StockMovement> StockMovement { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets StockTransactionType
        /// </summary>
        public virtual StockTransactionType StockTransactionType { get; set; }
    }
}
