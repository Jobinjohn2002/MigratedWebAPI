using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// The document audit class for auditing document information
    /// </summary>
    [Serializable]
    /// <summary>
    /// DocumentAuditDataContract
    /// </summary>
    public class DocumentAuditDataContract
    {
        [Serializable]
        /// <summary>
        /// DocumentDataContract
        /// </summary>
        public class DocumentDataContract
        {
            /// <summary>
            /// Gets or sets the Document Id for this audit
            /// </summary>
            /// <value>The document Id.</value>
            /// <remarks></remarks>
            /// <summary>
            /// Gets or sets DocumentId
            /// </summary>
            public int DocumentId { get; set; }

            /// <summary>
            /// Gets or sets the document type e.g. image or text document txt, pdf, doc, etc...
            /// </summary>
            /// <summary>
            /// Gets or sets DocumentTypeId
            /// </summary>
            public int DocumentTypeId { get; set; }

            /// <summary>
            /// Gets or sets the file name for the image or document
            /// </summary>
            /// <param name="fileName">The filename of the image or document</param>
            /// <summary>
            /// Gets or sets FileName
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// Gets or sets the item type for the image or document
            /// </summary>
            /// <param name="itemType">What type of item it is e.g. containerInstance, containerMaster, customerDefect</param>
            /// <summary>
            /// Gets or sets ImageTypeId
            /// </summary>
            public int ImageTypeId { get; set; }

            /// <summary>
            /// Gets or sets the identifier of type item type
            /// </summary>
            /// <param name="identifier">The id of the item e.g. containerInstanceId, containerMasterId, customerDefectId</param>
            /// <summary>
            /// Gets or sets ImageId
            /// </summary>
            public int ImageId { get; set; }

        }
        /// <summary>
        /// Gets or sets the Document object
        /// </summary>
        /// <summary>
        /// Gets or sets Document
        /// </summary>
        public DocumentDataContract Document { get; set; }

        /// <summary>
        /// Gets or sets the Document Audit Id
        /// </summary>
        /// <value>The document Audit Id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DocumentAuditId
        /// </summary>
        public int DocumentAuditId { get; set; }

        /// <summary>
        /// Gets or sets the Document Activity Id i.e. upload/deleted
        /// </summary>
        /// <value>The document Id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DocumentActivityTypeId
        /// </summary>
        public byte DocumentActivityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Order Source Id which is the app type identifier
        /// </summary>
        /// <value>The order source Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DocumentSourceId
        /// </summary>
        public int DocumentSourceId { get; set; }

        /// <summary>
        /// The datetime the audit was created
        /// </summary>
        /// <value>The UTC datetime </value>
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The user id of the user uploading deleting an image
        /// </summary>
        /// /// <value>The synergy trak userId</value>
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// The application source where the request came from
        /// </summary>
        /// <value>The requested source Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ApplicationRequestSourceId
        /// </summary>
        public int ApplicationRequestSourceId { get; set; }
    }
}

