using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DocumentGalleryModel
    /// </summary>
    public class DocumentGalleryModel
    {
        /// <summary>
        /// Gets or sets Documents
        /// </summary>
        public List<FileModel> Documents { get; set; }
    }
}