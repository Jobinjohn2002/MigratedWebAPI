using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
     /// <summary>
     /// IFileModel
     /// </summary>
     public interface IFileModel
    {
        /// <summary>
        /// 
        /// </summary>
       
         string BasePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
       
         string Path { get; set; }

        /// <summary>
        /// 
        /// </summary>        
       
         string FileName { get; set; }

       
         string ActualFileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
       
         bool IsPrimary { get; set; }

        /// <summary>
        /// 
        /// </summary>
       
         bool DisableAction { get; set; }

        /// <summary>
        /// 
        /// </summary>

         bool HasDerived { get; set; }

        /// <summary>
        /// 
        /// </summary>
       
         string DisplayImage { get; }
        

      

        /// <summary>
        /// 
        /// </summary>
       
         long FileSequence { get; set; }

       /// <summary>
       /// 
       /// </summary>
        string FileNameEncodeString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        PictureType FileType { get; set; }

        /// <summary>
        /// 
        /// </summary>
       
         string Extension { get; set; }

        /// <summary>
        /// 
        /// </summary>
       
         bool ReadOnly { get; set; }

        /// <summary>
        /// 
        /// </summary>

       
         int Identifier { get; set; }

       /// <summary>
       /// Definition id
       /// </summary>
         int? DefinitionId { get; set; }

       /// <summary>
       /// 
       /// </summary>
         int? MasterIdentifier { get; set; }

       /// <summary>
       /// 
       /// </summary>
         long Size { get; set; }
         
       /// <summary>
       /// 
       /// </summary>
         PictureType ImageType { get; set; }
         /// <summary>
         /// 
         /// </summary>
         string ImageTypeString { get; set; }
       
       /// <summary>
       /// 
       /// </summary>
         bool SlideShowNeedToStart { get; set; }

       /// <summary>
       /// 
       /// </summary>
         string ExternalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
       
         bool IsImage { get; set; }

       /// <summary>
       /// 
       /// </summary>
         string ItemTitle { get; set; }
       
       /// <summary>
       /// 
       /// </summary>
         int Height { get; set; }
         /// <summary>
         /// 
         /// </summary>
         int Width { get; set; }

         /// <summary>
         /// File In Bytes
         /// </summary>
         byte[] FileInBytes { get; set; }
       

       

      
    }
}
