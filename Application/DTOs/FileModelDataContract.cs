using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary>
    /// FileModelDataContract
    /// </summary>
    public class FileModelDataContract
    {
        /// <summary>
        /// 
        /// </summary>
        public FileModelDataContract() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public FileModelDataContract(IFileModel file)
        {
            Path = file.Path;
            FileName = file.FileName;
            Extension = file.Extension;
            ReadOnly = file.ReadOnly;
            ImageType = file.ImageType;
            Identifier = file.Identifier;
            Size = file.Size;
            ExternalId = file.ExternalId;
            IsImage = file.IsImage;
            MasterIdentifier = file.MasterIdentifier;
            DefinitionId = file.DefinitionId;
            FileSequence = file.FileSequence;
            IsPrimary = file.IsPrimary;
            ActualFileName = file.ActualFileName;
            BasePath = file.BasePath;
            FileInBytes = file.FileInBytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets BasePath
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        /// <summary>
        /// Gets or sets FileName
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets ActualFileName
        /// </summary>
        public string ActualFileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets IsPrimary
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets DisableAction
        /// </summary>
        public bool DisableAction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets HasDerived
        /// </summary>
        public bool HasDerived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayImage => ((IsImage) ? "" : "invisible");

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets FileSequence
        /// </summary>
        public long FileSequence { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets FileType
        /// </summary>
        public PictureType FileType { get; set; }

        /// <summary>
        /// List of additional file meta data
        /// </summary>
        /// <summary>
        /// Gets or sets AdditionalFileMetaDataList
        /// </summary>
        public List<FileMetaDataContract> AdditionalFileMetaDataList { get; set; }

        /// <summary>
        /// Extension
        /// </summary>
        /// <summary>
        /// Gets or sets Extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ReadOnly
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// File In Bytes
        /// </summary>
        public byte[] FileInBytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public int Identifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? DefinitionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? MasterIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets Size
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ImageType
        /// </summary>
        public PictureType ImageType { get; set; }
        public string ImageTypeString
        {
            get { return ImageType.ToString(); }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
            }
        }
        /// <summary>
        /// Gets or sets SlideShowNeedToStart
        /// </summary>
        public bool SlideShowNeedToStart { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets IsImage
        /// </summary>
        public bool IsImage { get; set; }
        /// <summary>
        /// Gets or sets ItemTitle
        /// </summary>
        public string ItemTitle { get; set; }
        /// <summary>
        /// Gets or sets Height
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Gets or sets Width
        /// </summary>
        public int Width { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public static FileModelDataContract Default
        {
            get
            {
                return new FileModelDataContract
                {
                    Extension = "png",
                    Path = "~/Content/Images/camera.png",
                    ReadOnly = true,
                    IsImage = true,
                    FileName = "camera.png"
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <summary>
        /// Equals operation
        /// </summary>
        public bool Equals(FileModelDataContract file)
        {
            return (file != null && Path == file.Path && FileName == file.FileName && Extension == file.Extension &&
                        ReadOnly == file.ReadOnly && ImageType == file.ImageType && Identifier == file.Identifier &&
                        Size == file.Size && ExternalId == file.ExternalId && IsImage == file.IsImage);
            
        }

        public string FileNameEncodeString
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}