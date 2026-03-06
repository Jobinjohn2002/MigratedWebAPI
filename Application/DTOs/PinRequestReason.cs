using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PinRequestReason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PinRequestReasonFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PinRequestReason()
        {
            this.ContainerMaster = new HashSet<ContainerMaster>();
            this.ItemMaster = new HashSet<ItemMaster>();
            this.Station = new HashSet<Station>();
            this.TurnaroundEvent = new HashSet<TurnaroundEvent>();
            this.BiologicalIndicatorTest = new HashSet<BiologicalIndicatorTest>();
            this.SterilisationTestReport = new HashSet<SterilisationTestReport>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PinRequestReasonId
        /// </summary>
        public int PinRequestReasonId { get; set; }
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
        /// Gets or sets ContainerMaster
        /// </summary>
        public virtual ICollection<ContainerMaster> ContainerMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public virtual ICollection<ItemMaster> ItemMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual ICollection<Station> Station { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual ICollection<TurnaroundEvent> TurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets BiologicalIndicatorTest
        /// </summary>
        public virtual ICollection<BiologicalIndicatorTest> BiologicalIndicatorTest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReport
        /// </summary>
        public virtual ICollection<SterilisationTestReport> SterilisationTestReport { get; set; }
    }
}
