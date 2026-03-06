using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ImageGallerySecureModel
    /// </summary>
    public class ImageGallerySecureModel
    {
        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets PrimaryImage
        /// </summary>
        public ImageGalleryUrlModel PrimaryImage { get; set; }

        /// <summary>
        /// Gets or sets Thumbnails
        /// </summary>
        public List<ImageGalleryUrlModel> Thumbnails { get; set; }
    }

    /// <summary>
    /// ImageGalleryUrlModel
    /// </summary>
    public class ImageGalleryUrlModel
    {

        /// <summary>
        /// Gets or sets DownloadUrl
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets PreviewUrl
        /// </summary>
        public string PreviewUrl { get; set; }

        /// <summary>
        /// Gets or sets ThumbnailUrl
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets UserCanDelete
        /// </summary>
        public bool UserCanDelete { get; set; }

        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets ImageName
        /// </summary>
        public string ImageName { get; set; }
    }
}