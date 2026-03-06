using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ResultPicker
    /// </summary>
    public class ResultPicker
    {
        public ResultPicker()
        {
            Groups = new List<ResultGroup>();
        }

        /// <summary>
        /// Gets or sets ShowInGroups
        /// </summary>
        public bool ShowInGroups { get; set; }
        /// <summary>
        /// Gets or sets GroupSelectable
        /// </summary>
        public bool GroupSelectable { get; set; }

        /// <summary>
        /// Gets or sets Groups
        /// </summary>
        public List<ResultGroup> Groups { get; set; }
    }

    /// <summary>
    /// ResultGroup
    /// </summary>
    public class ResultGroup : ResultItem
    {
        public ResultGroup()
        {
            Items = new List<ResultItem>();
        }

        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<ResultItem> Items { get; set; }
    }

    /// <summary>
    /// ResultItem
    /// </summary>
    public class ResultItem
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
    }
}