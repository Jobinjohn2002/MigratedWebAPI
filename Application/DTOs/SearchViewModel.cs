using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchCategory
    /// </summary>
    public class SearchCategory
    {
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public SearchCategoryType Type { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }

    /// <summary>
    /// SearchViewArgs
    /// </summary>
    public class SearchViewArgs
    {
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

        public SearchCategoryType? Categories { get; set; }

        /// <summary>
        /// Includes operation
        /// </summary>
        public bool Includes(SearchCategoryType type)
        {
            var val = Categories.GetValueOrDefault();

            if (val == SearchCategoryType.All || val.HasFlag(type))
                return true;

            return false;
        }

        /// <summary>
        /// IsNumeric operation
        /// </summary>
        public bool IsNumeric()
        {
            long val;

            return long.TryParse(Text, out val);
        }
    }

    /// <summary>
    /// SearchViewModel
    /// </summary>
    public class SearchViewModel
    {
        public enum SearchContext
        {
            Customer = 0,
            Administration = 1
        }

        public enum ExecutionResult
        {
            Success = 0,
            TooFewCharacters = 1
        }

        public SearchViewModel()
        {
            Categories = new List<SearchCategory>();
            Results = new List<SearchViewResult>();
        }

        /// <summary>
        /// Gets or sets Context
        /// </summary>
        public SearchContext Context { get; set; }

        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public ExecutionResult Result { get; set; }

        /// <summary>
        /// Gets or sets Args
        /// </summary>
        public SearchViewArgs Args { get; set; }

        /// <summary>
        /// Gets or sets Categories
        /// </summary>
        public List<SearchCategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets Results
        /// </summary>
        public List<SearchViewResult> Results { get; set; }

        /// <summary>
        /// AddCategory operation
        /// </summary>
        public void AddCategory(SearchCategoryType type, int count, ITranslator translator)
        {
            Categories.Add(new SearchCategory
            {
                Count = count,
                Name = translator.GetText("enum", "SearchCategoryType", type.ToString("G")),
                Type = type
            });
        }
    }
}