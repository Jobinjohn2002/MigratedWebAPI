using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// NoticeWidgetModel
    /// </summary>
    public class NoticeWidgetModel
    {
        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }
}