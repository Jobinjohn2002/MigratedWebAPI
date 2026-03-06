using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Details
    /// </summary>
    public class Details
    {
        /// <summary>
        /// Gets or sets Report
        /// </summary>
        public MaintenanceReport Report { get; set; }

        public Searchable UserDefinedRefSearchable => new Searchable(Report?.UserDefinedRef, SearchViewModel.SearchContext.Customer);
    }
}