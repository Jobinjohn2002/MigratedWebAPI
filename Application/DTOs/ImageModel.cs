using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ImageModel
    /// </summary>
    public class ImageModel : FileModel
    {

        /// <summary>
        /// 
        /// </summary>
        public ImageModel()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public ImageModel(FileModel file): base(file)
        {

        }
        /// <summary>
        /// GetImageUrl operation
        /// </summary>
        public string GetImageUrl()
        {
            switch (Extension.ToLower())
            {
                case ".pdf":
                    return "~/Content/Images/pdf.png";
                case ".xlsx":
                case ".xls":
                    return "~/Content/Images/excel.png";
                case ".docx":
                case ".doc":
                    return "~/Content/Images/word.png";
                case ".txt":
                    return "~/Content/Images/notepad.png";
                default:
                    return Path;
            }

        }

    }
}
