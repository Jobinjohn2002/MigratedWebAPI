using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class FileExtensions
    {
        public static byte[] ReadFileContents(HttpPostedFileBase file)
        {
            Stream fileStream = file.InputStream;
            var memStream = new MemoryStream();
            memStream.SetLength(fileStream.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            while (fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length) > 0)
            {
            }

            return memStream.GetBuffer();
        }

        /// <summary>
        /// ReadFileType operation
        /// </summary>
        public static string ReadFileType(HttpPostedFileBase file)
        {
            var fileType = String.Empty;
            if (file.FileName != null)
            {
                fileType = Path.GetFileName(file.FileName);
                fileType = fileType.Substring(fileType.LastIndexOf(".") + 1);
            }

            return fileType;
        }

        /// <summary>
        /// BuildFilePath operation
        /// </summary>
        public static string BuildFilePath(KnownFileType fileType, string path, string fileName)
        {
            if (!path.EndsWith(@"\"))
                path += @"\";

            var filePath = path + fileName;

            switch (fileType)
            {
                case (KnownFileType.PDF):
                    filePath += ".pdf";
                    break;
                case (KnownFileType.JPG):
                    filePath += ".jpg";
                    break;
                case (KnownFileType.BMP):
                    filePath += ".bmp";
                    break;
                case (KnownFileType.PNG):
                    filePath += ".png";
                    break;
                case (KnownFileType.DOC):
                    filePath += ".doc";
                    break;
                case (KnownFileType.DOCX):
                    filePath += ".docx";
                    break;
                case (KnownFileType.XLS):
                    filePath += ".xls";
                    break;
                case (KnownFileType.XLSX):
                    filePath += ".xlsx";
                    break;
                default:
                    throw new InvalidOperationException("Unknown filetype");
            }

            return filePath;
        }

        /// <summary>
        /// SaveFile operation
        /// </summary>
        public static void SaveFile(byte[] fileContent, string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            fileInfo.Directory.Create(); // If the directory already exists this method does nothing
            File.WriteAllBytes(fileInfo.FullName, fileContent);
        }
    }
}
