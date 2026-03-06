using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// JobListModel
    /// </summary>
    public class JobListModel
    {
        /// <summary>
        /// Gets or sets Jobs
        /// </summary>
        public IList<JobInfo> Jobs { get; set; }
    }
}