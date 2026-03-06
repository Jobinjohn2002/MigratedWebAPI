using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TestReportTemperature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TestReportTemperatureFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TestReportTemperature()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationTestReportId
        /// </summary>
        public int SterilisationTestReportId { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTemperatureId
        /// </summary>
        public int SterilisationTemperatureId { get; set; }
        /// <summary>
        /// Gets or sets Allowed
        /// </summary>
        public bool Allowed { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationTemperature
        /// </summary>
        public virtual SterilisationTemperature SterilisationTemperature { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReport
        /// </summary>
        public virtual SterilisationTestReport SterilisationTestReport { get; set; }
    }
}
