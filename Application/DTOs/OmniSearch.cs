using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OmniSearch
    /// </summary>
    public class OmniSearch
    {
        /// <summary>
        /// Gets or sets Controller
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Gets or sets Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets ActionInfo
        /// </summary>
        public ActionInfo ActionInfo { get; set; }
        /// <summary>
        /// Gets or sets SearchValue
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets FindSingleCategory
        /// </summary>
        public bool FindSingleCategory { get; set; }
        /// <summary>
        /// Gets or sets Results
        /// </summary>
        public IList<OmniSearchResults> Results { get; set; }
        /// <summary>
        /// Gets or sets OmniSearchTableModel
        /// </summary>
        public TableModel OmniSearchTableModel { get; set; }
        /// <summary>
        /// Gets or sets Args
        /// </summary>
        public OmniSearchArgs Args { get { return new OmniSearchArgs(); }}
        /// <summary>
        /// Gets or sets Categories
        /// </summary>
        public List<Category> Categories { get; set; }
        /// <summary>
        /// Gets or sets CategoriesInUrl
        /// </summary>
        public NameValueCollection CategoriesInUrl { get; set; }
    }

    /// <summary>
    /// Category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets DictionaryName
        /// </summary>
        public string DictionaryName { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }
}