using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class BiologicalIndicatorTestData 
	{

	    public BiologicalIndicatorTestData()
	    {
	       
	    }

	    /// <summary>
        /// Is Biological Indicator Enabled flag
        /// </summary>
        /// <summary>
        /// Gets or sets IsBiologicalIndicatorEnabled
        /// </summary>
        public bool IsBiologicalIndicatorEnabled { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorTestStatusText
        /// </summary>
        public string BiologicalIndicatorTestStatusText { get; set; }
        /// <summary>
        /// Gets or sets TestedBy
        /// </summary>
        public string TestedBy { get; set; }
        /// <summary>
        /// Gets or sets ReviewdBy
        /// </summary>
        public string ReviewdBy { get; set; }

        /// <summary>
        /// Gets and sets Batch Status Id
        /// </summary>
        public int? BatchStatusId { get; set; }
	}

}
		