using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BinaryDataContract
    /// </summary>
    public class BinaryDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Files
        /// </summary>
        public List<FileContract> Files { get; set; }
        /// <summary>
        /// Gets or sets Version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Gets or sets Xml
        /// </summary>
        public string Xml { get; set; }
        /// <summary>
        /// Gets or sets ApiUrl
        /// </summary>
        public string ApiUrl { get; set; }
    }
}