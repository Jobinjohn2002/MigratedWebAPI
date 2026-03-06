using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IDocumentAndImageService
    /// </summary>
    public interface IDocumentAndImageService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="id"></param>
        /// <param name="itemType"></param>
        /// <param name="externalId"></param>
        /// <param name="definitionId"></param>
        /// <returns></returns>
        byte[] FileToByteArray(string fileName, int id, PictureType itemType, string externalId, int? definitionId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="identifier"></param>
        /// <param name="itemType"></param>
        /// <param name="masterId"></param>
        /// <param name="externalId"></param>
        /// <param name="displayBothImages"></param>
        /// <returns></returns>
        FileModelDataContract GetLargeImage(string imageName, int identifier, PictureType itemType, int? masterId, string externalId,
                                bool? displayBothImages);
        /// <summary>
        /// Get image in bytes
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="identifier"></param>
        /// <param name="itemType"></param>
        /// <param name="masterId"></param>
        /// <param name="externalId"></param>
        /// <param name="displayBothImages"></param>
        /// <returns></returns>
        byte[] GetImageInBytes(string imageName, int identifier, PictureType itemType, int? masterId,
                               string externalId, bool? displayBothImages);
        /// <summary>
        /// Get File Model
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="identifier"></param>
        /// <param name="itemType"></param>
        /// <param name="masterId"></param>
        /// <param name="externalId"></param>
        /// <param name="displayBothImages"></param>
        /// <returns></returns>
        FileModelDataContract GetImageFileModel(string imageName, int identifier, PictureType itemType,
                                           int? masterId, string externalId, bool? displayBothImages);

        /// <summary>
        /// Get Documents List
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="imageType"></param>
        /// <param name="definitionId"></param>
        /// <param name="externalId"></param>
        /// <param name="displayMasterImage"></param>
        /// <param name="readOnly"></param>
        /// <returns></returns>
        FileModelDataContract GetDocumentsList(int identifier, PictureType imageType, int? definitionId, string externalId, bool displayMasterImage, bool readOnly = true);

    }
}
