using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TaskItem
    /// </summary>
    public class TaskItem
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
        /// Gets or sets DateLabel
        /// </summary>
        public string DateLabel { get; set; }
        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }
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
    /// TaskModel
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// Gets or sets Tasks
        /// </summary>
        public List<TaskItem> Tasks { get; set; }
    }
}