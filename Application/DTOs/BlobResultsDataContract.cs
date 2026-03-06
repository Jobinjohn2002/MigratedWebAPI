using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BlobResultsDataContract
    /// </summary>
    public class BlobResultsDataContract
    {
        /// <summary>
        /// Gets or sets ListOfBlobs
        /// </summary>
        public IEnumerable<SterisCloudBlobDataContract> ListOfBlobs { get; set; }
        /// <summary>
        /// Gets or sets ContainerSasToken
        /// </summary>
        public string ContainerSasToken { get; set; }
        /// <summary>
        /// Gets or sets PreviewsSasToken
        /// </summary>
        public string PreviewsSasToken { get; set; }
    }
    /// <summary>
    /// SterisCloudBlobDataContract
    /// </summary>
    public class SterisCloudBlobDataContract
    {
        /// <summary>
        /// Gets or sets MetaData
        /// </summary>
        public IDictionary<string, string> MetaData { get; set; }
        /// <summary>
        /// Gets or sets StorageUri
        /// </summary>
        public string StorageUri { get; set; }
        /// <summary>
        /// Gets or sets ContainerName
        /// </summary>
        public string ContainerName { get; set; }
    }
}
