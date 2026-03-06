using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FileModel
    /// </summary>
    public class FileModel
    {
        public FileModel() { }

        public FileModel(FileModel file)
        {
            Path = file.Path;
            FileName = file.FileName;
            Extension = file.Extension;
            AssociatedFileType = file.AssociatedFileType;
            Identifier = file.Identifier;
            Size = file.Size;
            ExternalId = file.ExternalId;
            MasterIdentifier = file.MasterIdentifier;
            FileNameEncodeString = file.FileNameEncodeString;
            DisplayBothImages = file.DisplayBothImages;
            DisplaySize = file.DisplaySize;
        }

        /// <summary>
        /// Gets or sets MasterFirstImageOnly
        /// </summary>
        public bool MasterFirstImageOnly { get; set; }

        /// <summary>
        /// Gets or sets UserCanDelete
        /// </summary>
        public bool UserCanDelete { get; set; }

        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Files
        /// </summary>
        public List<ImageViewerModel> Files { get; set; }

        /// <summary>
        /// Gets or sets FirstFile
        /// </summary>
        public ImageViewerModel FirstFile { get; set; }

        public bool? DisplayBothImages { get; set; }

        /// <summary>
        /// Gets or sets Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets FileName
        /// </summary>
        public string FileName { get; set; }

        public string DisplayFileName
        {
            get
            {
                string regex = @"\d*_\w{1,2}_";
                var match = Regex.Match(FileName, regex);
                if (match.Success && match.Index == 0)
                {
                    return FileName.Substring(match.Length);
                }
                else
                {
                    return FileName;
                }
            }
        }
        public string FileNameEncodeString
        {
            get
            {
                return FileName.Length > 0 ? FileName.ToBase64() : string.Empty;
            }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }
        
        /// <summary>
        /// Gets or sets Extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public int Identifier { get; set; }

        public int? MasterIdentifier { get; set; }

        [ConfigurationProperty("maxRequestLength", DefaultValue = 1024)]
        /// <summary>
        /// Gets or sets Size
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets AssociatedFileType
        /// </summary>
        public AssociatedObjectType AssociatedFileType { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets ItemsExternalId
        /// </summary>
        public string ItemsExternalId { get; set; }

        /// <summary>
        /// Gets or sets DisplaySize
        /// </summary>
        public string DisplaySize { get; set; }
        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }
    }
}