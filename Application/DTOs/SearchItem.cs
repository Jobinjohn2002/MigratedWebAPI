using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchItem
    /// </summary>
    public class SearchItem
    {
        /// <summary>
        /// Gets or sets Data
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Create operation
        /// </summary>
        public static SearchItem Create(object data, string name, string key)
        {
            return new SearchItem() { Data = data, Name = name, Key = key };
        }

        /// <summary>
        /// ToString operation
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}