using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyPrint
    /// </summary>
    public class TrolleyPrint
    {
        /// <summary>
        /// Gets or sets TrolleyPrimaryId
        /// </summary>
        public string TrolleyPrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ChildContainers
        /// </summary>
        public IEnumerable<TrolleyContents> ChildContainers { get; set; }
    }
}