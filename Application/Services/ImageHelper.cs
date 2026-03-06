using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ImageHelper
    {
        /// <summary>
        /// HasImages operation
        /// </summary>
        public static bool HasImages(int id, string folder, AssociatedObjectType associatedFileType, bool displayPrimaryMasterImage, IDirectory directory)
        {
            return HasImages(id, folder, associatedFileType, displayPrimaryMasterImage, default(int), AssociatedObjectType.ContainerMaster, directory);
        }

        /// <summary>
        /// HasImages operation
        /// </summary>
        public static bool HasImages(int id, string folder, AssociatedObjectType associatedFileType, bool displayPrimaryMasterImage, int containerMasterDefinitionId, IDirectory directory)
        {
            return HasImages(id, folder, associatedFileType, displayPrimaryMasterImage, containerMasterDefinitionId, AssociatedObjectType.ContainerMaster, directory);
        }

        /// <summary>
        /// HasImages operation
        /// </summary>
        public static bool HasImages(int id, string folder, AssociatedObjectType associatedFileType, bool displayPrimaryMasterImage, int containerMasterDefinitionId, AssociatedObjectType masterAssociatedFileType, IDirectory directory)
        {
            var foundFiles = false;

            var path = Path.Combine(folder, associatedFileType.ToString(), id.ToString());

            Func<string, bool> predicate = f =>
                f.ToLower().EndsWith(".jpeg", true, CultureInfo.InvariantCulture) ||
                f.ToLower().EndsWith(".jpg", true, CultureInfo.InvariantCulture) ||
                f.ToLower().EndsWith(".gif", true, CultureInfo.InvariantCulture) ||
                f.ToLower().EndsWith(".tiff", true, CultureInfo.InvariantCulture) ||
                f.ToLower().EndsWith(".tif", true, CultureInfo.InvariantCulture) ||
                f.ToLower().EndsWith(".bmp", true, CultureInfo.InvariantCulture) ||
                f.ToLower().EndsWith(".png", true, CultureInfo.InvariantCulture);

            if (directory.Exists(path))
            {
                var files = directory
                    .GetFiles(path)
                    .Where(predicate)
                    .ToList();

                if (files.Count > 0)
                {
                    foundFiles = true;
                }
                else
                {
                    if (displayPrimaryMasterImage)
                    {
                        path = Path.Combine(folder, masterAssociatedFileType.ToString(), containerMasterDefinitionId.ToString());

                        if (directory.Exists(path))
                        {
                            files = directory
                                .GetFiles(path)
                                .Where(predicate)
                                .ToList();

                            foundFiles = DoesPrimaryImageExist(files);
                        }
                    }
                }
            }

            return foundFiles;
        }

        /// <summary>
        /// DoesPrimaryImageExist operation
        /// </summary>
        public static bool DoesPrimaryImageExist(List<string> files)
        {
            if (files == null || files.Count == 0)
            {
                return false;
            }

            var isPrimaryFile = false;

            foreach (var s in files)
            {
                var start = s.LastIndexOf(@"\", StringComparison.InvariantCulture) + 1;
                var end = s.Length - start;
                var filename = s.Substring(start, end);

                if (filename.StartsWith("0"))
                {
                    isPrimaryFile = true;
                    break;
                }
            }

            return isPrimaryFile;
        }
    }
}