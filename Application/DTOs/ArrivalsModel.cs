using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ArrivalsModel
    /// </summary>
    public class ArrivalsModel : BaseModel
    {
        /// <summary>
        /// Gets or sets ETATableModel
        /// </summary>
        public TableModel ETATableModel { get; set; }
    }
}