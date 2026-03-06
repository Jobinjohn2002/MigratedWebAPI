using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OutlookItem
    /// </summary>
    public class OutlookItem
    {
        /// <summary>
        /// Gets or sets ActionInfo
        /// </summary>
        public ActionInfo ActionInfo { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets Heading
        /// </summary>
        public string Heading { get; set; }
        /// <summary>
        /// Gets or sets SubHeading
        /// </summary>
        public string SubHeading { get; set; }
        /// <summary>
        /// Gets or sets Body
        /// </summary>
        public string Body { get; set; }
    }

    /// <summary>
    /// NoticeModel
    /// </summary>
    public class NoticeModel
    {
        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<OutlookItem> Items { get; set; }
    }
}