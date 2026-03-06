using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FileContract
    /// </summary>
    public class FileContract
    {
        public byte[] Data { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets DirectoryName
        /// </summary>
        public string DirectoryName { get; set; }
        /// <summary>
        /// Gets or sets Filename
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// Gets or sets FullFilename
        /// </summary>
        public string FullFilename { get; set; }
        /// <summary>
        /// Gets or sets ContentDownloaded
        /// </summary>
        public bool ContentDownloaded { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
    }
}