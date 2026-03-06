using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DocumentDataContract
    /// </summary>
    public class DocumentDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets AvailableFiles
        /// </summary>
        public int AvailableFiles { get; set; }
        /// <summary>
        /// Gets or sets Files
        /// </summary>
        public List<FileContract> Files { get; set; }
    }
}