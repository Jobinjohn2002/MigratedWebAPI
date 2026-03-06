using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Searchable
    /// </summary>
    public class Searchable
    {
        public Searchable(string searchText, SearchViewModel.SearchContext context)
        {
            SearchText = searchText;
            Context = context;
        }

        /// <summary>
        /// Gets or sets SearchText
        /// </summary>
        public string SearchText { get; set; }
        public SearchViewModel.SearchContext Context { get; set; }
    }
}