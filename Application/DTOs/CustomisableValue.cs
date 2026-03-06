using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomisableValue
    /// </summary>
    public class CustomisableValue
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets IsSystem
        /// </summary>
        public bool IsSystem { get; set; }
    }
}