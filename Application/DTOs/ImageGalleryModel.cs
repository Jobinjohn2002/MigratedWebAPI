using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ImageGalleryModel
    /// </summary>
    public class ImageGalleryModel
    {
        /// <summary>
        /// Gets or sets PrimaryImage
        /// </summary>
        public ActionInfo PrimaryImage { get; set; }

        /// <summary>
        /// Gets or sets Thumbnails
        /// </summary>
        public List<ActionInfo> Thumbnails { get; set; }
    }
}