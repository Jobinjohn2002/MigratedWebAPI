using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Specification Note Info.
    /// </summary>
    [HelpPartial(@"~\Areas\Customer\Views\Specification\_ComponentPositionNotes.cshtml", DisplayOption.AfterDetails, 1)]
    /// <summary>
    /// SpecificationNoteInfo
    /// </summary>
    public class SpecificationNoteInfo
    {
        /// <summary>
        /// The position of the component within the overall specification.
        /// </summary>
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// The note text.
        /// </summary>
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    }
}