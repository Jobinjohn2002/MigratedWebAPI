using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class BatchData
	{
		public BatchData(IBatch batch, string cycleTypeName)
			: this(batch)
		{
			CycleTypeName = cycleTypeName;
		}
		#region extra data
		/// <summary>
		/// Gets or sets CycleTypeName
		/// </summary>
		public string CycleTypeName { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorExists
        /// </summary>
        public bool BiologicalIndicatorExists { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorEnabled
        /// </summary>
        public bool BiologicalIndicatorEnabled { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorTestsPerFormed
        /// </summary>
        public bool BiologicalIndicatorTestsPerFormed { get; set; }
        public bool? BiologicalIndicatorTestResult {get;set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorTestArchived
        /// </summary>
        public bool BiologicalIndicatorTestArchived { get; set; }
        /// <summary>
        /// Gets or sets MachineName
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// Gets or sets BatchFailureReason
        /// </summary>
        public string BatchFailureReason { get; set; }
        /// <summary>
        /// Gets or sets BatchFailureExtraInfo
        /// </summary>
        public string BatchFailureExtraInfo { get; set; }

		#endregion extra data
	}
}