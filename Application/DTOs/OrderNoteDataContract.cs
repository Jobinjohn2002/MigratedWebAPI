using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderNoteDataContract
    /// </summary>
    public class OrderNoteDataContract
    {
        /// <summary>
        /// Gets or sets Sequence
        /// </summary>
        public int Sequence { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    }
}