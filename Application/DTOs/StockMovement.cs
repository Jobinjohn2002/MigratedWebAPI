using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class StockMovement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StockMovementFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public StockMovement()
        {
            this.MaintenanceReportInstrumentDetail = new HashSet<MaintenanceReportInstrumentDetail>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StockMovementId
        /// </summary>
        public int StockMovementId { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets StockTransactionId
        /// </summary>
        public int StockTransactionId { get; set; }
    
        /// <summary>
        /// Gets or sets ItemMasterDefinition
        /// </summary>
        public virtual ItemMasterDefinition ItemMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets StockTransaction
        /// </summary>
        public virtual StockTransaction StockTransaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MaintenanceReportInstrumentDetail
        /// </summary>
        public virtual ICollection<MaintenanceReportInstrumentDetail> MaintenanceReportInstrumentDetail { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public virtual Location Location { get; set; }
    }
}
