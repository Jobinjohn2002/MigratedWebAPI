using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ImageViewerModel
    /// </summary>
    public class ImageViewerModel
    {
        public ImageViewerModel() { }

        public ImageViewerModel(int identifier, string imageName, ImageSize imageSize, AssociatedObjectType associatedFileType)
        {
            Identifier = identifier;
            ImageName = imageName;
            ImageSize = imageSize;
            AssociatedFileType = associatedFileType;
        }

        /// <summary>
        /// Gets or sets ImageName
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public int Identifier { get; set; }
        /// <summary>
        /// Gets or sets AssociatedFileType
        /// </summary>
        public AssociatedObjectType AssociatedFileType { get; set; }
        /// <summary>
        /// Gets or sets ImageSize
        /// </summary>
        public ImageSize ImageSize { get; set; }
        /// <summary>
        /// Gets or sets UserCanDelete
        /// </summary>
        public bool UserCanDelete { get; set; }

    }
}