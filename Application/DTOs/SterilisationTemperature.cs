using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SterilisationTemperature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SterilisationTemperatureFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SterilisationTemperature()
        {
            this.TestReportTemperature = new HashSet<TestReportTemperature>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationTemperatureId
        /// </summary>
        public int SterilisationTemperatureId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TestReportTemperature
        /// </summary>
        public virtual ICollection<TestReportTemperature> TestReportTemperature { get; set; }
    }
}
