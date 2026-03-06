using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class GetStationeryVersion_Result
    {
        /// <summary>
        /// Gets or sets ReportPath
        /// </summary>
        public string ReportPath { get; set; }
        /// <summary>
        /// Gets or sets NumberOfCopies
        /// </summary>
        public Nullable<int> NumberOfCopies { get; set; }
    }
}
