using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Obsolete("Use the Synergy.Core.Data.DataFilter instead")]
    /// <summary>
    /// DataFilter
    /// </summary>
    public class DataFilter
    {
        /// <summary>
        /// Gets or sets SortExpression
        /// </summary>
        public string SortExpression { get; set; }
        /// <summary>
        /// Gets or sets CurrentPageIndex
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// Gets or sets ItemsPerPage
        /// </summary>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// Gets or sets SearchCriteria
        /// </summary>
        public string SearchCriteria { get; set; }
        /// <summary>
        /// Gets or sets SortColumn
        /// </summary>
        public string SortColumn { get; set; }
        /// <summary>
        /// Gets or sets SortAscending
        /// </summary>
        public bool SortAscending { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// ToKeyValuePairList operation
        /// </summary>
        public List<KeyValuePair<string, string>> ToKeyValuePairList()
        {
            var keyValuePair = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(SearchCriteria)) {

                keyValuePair = (from item in SearchCriteria.Split('|').ToList()
                                let column = item.Split('~')[0]
                                let value = item.Split('~')[1]
                                select new KeyValuePair<string, string>(column, value)).ToList();
            }

            return keyValuePair;
            
        }
    }
}
