using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerIndexationSummaryData
    /// </summary>
    public class CustomerIndexationSummaryData
    {
        public CustomerIndexationSummaryData()
        { }

        public CustomerIndexationSummaryData(ICustomerIndexationSummary data)
        {
            IndexationCategoryId = data.IndexationCategoryId;
            Name = data.Name;
            IndexationFactor = data.IndexationFactor;
        }

        public CustomerIndexationSummaryData(int indexationCategoryId, string name, decimal indexationFactor)
        {
            IndexationCategoryId = indexationCategoryId;
            Name = name;
            IndexationFactor = indexationFactor;
        }
        /// <summary>
        /// Gets or sets IndexationCategoryId
        /// </summary>
        public int IndexationCategoryId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets IndexationFactor
        /// </summary>
        public decimal IndexationFactor { get; set; }
    }
}
