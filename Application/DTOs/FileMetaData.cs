using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FileMetaData
    /// </summary>
    public class FileMetaData
    {
        /// <summary>
        /// File name
        /// </summary>
        /// <summary>
        /// Gets or sets FileName
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Actual File Name
        /// </summary>
        /// <summary>
        /// Gets or sets ActualFileName
        /// </summary>
        public string ActualFileName { get; set; }
        /// <summary>
        /// File extension
        /// </summary>
        /// <summary>
        /// Gets or sets FileExtension
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// File server path
        /// </summary>
        /// <summary>
        /// Gets or sets FileServerPath
        /// </summary>
        public string FileServerPath { get; set; }
        /// <summary>
        /// File sequence
        /// </summary>
        /// <summary>
        /// Gets or sets FileSequence
        /// </summary>
        public long FileSequence { get; set; }
    }
}
