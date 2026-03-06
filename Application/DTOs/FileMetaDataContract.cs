using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FileMetaDataContract
    /// </summary>
    public class FileMetaDataContract
    {

        /// <summary>
        /// constructor
        /// </summary>
        public FileMetaDataContract() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fileMetaData"></param>
        public FileMetaDataContract(IFileMetaData fileMetaData)
        {
            FileName = fileMetaData.FileName;
            FileExtension = fileMetaData.FileExtension;
            FileServerPath = fileMetaData.FileServerPath;
            FileSequence = fileMetaData.FileSequence;
            ActualFileName = fileMetaData.ActualFileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets FileName
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets FileExtension
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets FileServerPath
        /// </summary>
        public string FileServerPath { get; set; }
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
        /// Gets or sets ActualFileName
        /// </summary>
        public string ActualFileName { get; set; }
    }
}
