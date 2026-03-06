using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// DocumentAuditHelper
    /// </summary>
    public class DocumentAuditHelper
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        public DocumentAuditHelper()
        {
        }

        #region public methods
        /// <summary>
        /// Create the document if it doesn't exist then create the audit for the uploaded/deleted event
        /// <param name="docAudit">The document audit datacontract that stores document and audit details, who it was created by, where it was created, etc.. </param>
        /// <returns>The document audit id</returns>
        /// <summary>
        /// CreateDocumentAudit operation
        /// </summary>
        public int CreateDocumentAudit(DocumentAuditDataContract docAudit)
        {
            int result = int.MinValue;
            var documentId = int.MinValue;

            if (docAudit.Document.DocumentId == int.MinValue)
            {
                documentId = CreateDocument(docAudit);
            }
            else
            {
                documentId = docAudit.Document.DocumentId;
            }

            if (documentId == int.MinValue) return result;

            using (var repository = new PathwayRepository())
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var docAuditModel = DocumentAuditFactory.CreateEntity(workUnit,
                        documentActivityTypeId: docAudit.DocumentActivityTypeId,
                        documentSourceId: docAudit.DocumentSourceId,
                        created: DateTime.UtcNow,
                        createdByUserId: docAudit.CreatedByUserId
                    );

                    repository.Container.Document.FirstOrDefault(a => a.DocumentId == documentId).DocumentAudit.Add(docAuditModel);
                    repository.Container.SaveChanges();
                    result = docAuditModel.DocumentAuditId;
                }
            }

            return result;
        }
    
        /// <summary>
        /// Check if the document is restricted for delete for the docoument audit details
        /// <param name="docAudit">The document audit datacontract that stores document and audit details, who it was created by, where it was created, etc.. </param>
        /// <returns>The restriction on delete</returns>
        /// <summary>
        /// IsDocumentRestricted operation
        /// </summary>
        public bool IsDocumentRestricted(DocumentAuditDataContract docAudit)
        {
            {
                Document document = GetDocument(docAudit);

                if (document == null)
                {
                    return false;
                }
                
                List<int> AppList = new List<int>(2);

                AppList.Add((int)Enums.General.DocumentSourceIdentifier.SAF);
                AppList.Add((int)Enums.General.DocumentSourceIdentifier.Operative);

                var lastAppUsed = (int)Enums.General.DocumentSourceIdentifier.SAF;

                DateTime latestDateTime = new DateTime();
                foreach (var app in AppList)
                {
                    var docAuditLatestAppRecordUploaded =
                        repository.Container.DocumentAudit.OrderByDescending(a => a.Created).FirstOrDefault
                        (
                            a => a.DocumentId == document.DocumentId
                            && a.DocumentSourceId == app
                            && a.DocumentActivityTypeId == (int)Enums.DocumentActivityTypeIdentifier.Uploaded
                        );
                    if (docAuditLatestAppRecordUploaded?.Created > latestDateTime)
                    {
                        latestDateTime = docAuditLatestAppRecordUploaded.Created;
                        lastAppUsed = app;
                    }
                }
        
                var docAuditAppRecordUploaded = 
                    repository.Container.DocumentAudit.OrderByDescending(a => a.Created).FirstOrDefault
                    (
                        a => a.DocumentId == document.DocumentId
                        && a.DocumentSourceId == lastAppUsed
                        && a.DocumentActivityTypeId == (int)Enums.DocumentActivityTypeIdentifier.Uploaded
                    );

                if (docAuditAppRecordUploaded == null)
                    return false; // no records

                var docAuditAppRecordDeleted = 
                    repository.Container.DocumentAudit.OrderByDescending(a => a.Created).FirstOrDefault
                    (
                        a => a.DocumentId == document.DocumentId
                        && a.DocumentSourceId == lastAppUsed
                        && a.DocumentActivityTypeId == (int)Enums.DocumentActivityTypeIdentifier.Deleted
                    );
                var canDeleteFromApp = false;

                canDeleteFromApp = (int)docAudit.ApplicationRequestSourceId == lastAppUsed;
                if (docAudit.ApplicationRequestSourceId == (int)Enums.General.DocumentSourceIdentifier.Admin 
                    && lastAppUsed == (int)Enums.General.DocumentSourceIdentifier.Operative)
                {
                    canDeleteFromApp = true;
                }

                if (docAuditAppRecordUploaded != null && docAuditAppRecordDeleted != null)
                {
                    if (docAuditAppRecordDeleted.Created > docAuditAppRecordUploaded.Created)
                    {
                        return true;
                    }
                    else
                    {
                        return !canDeleteFromApp;
                    }
                }
                else if (docAuditAppRecordUploaded != null && docAuditAppRecordDeleted == null)
                {
                    return !canDeleteFromApp;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region private methods

        /// <summary>
        /// Create the document which can be an image or text based document
        /// </summary>
        /// <param name="docAudit">The document datacontract that stores the document details</param>
        /// <returns>documentId</returns>
        private int CreateDocument(DocumentAuditDataContract docAudit)
        {
            int result = int.MinValue;
            Document document = GetDocument(docAudit);

            if (document == null) return result;

            if(document.DocumentId == int.MinValue)
            { 
                {
                    repository.Container.Document.AddObject(document);
                    repository.Container.SaveChanges();
                }
            }
            result = document.DocumentId;

            return result;
        }

        /// <summary>
        /// Get the document if it exists if not return null
        /// </summary>
        /// <param name="docAudit">The document datacontract that stores the document details</param>
        /// <returns>The document or null if doesn't exist</returns>
        private Document GetDocument(DocumentAuditDataContract docAudit)
        {
            Document document = null;
            {
                document = repository.Container.Document.FirstOrDefault
                (
                    doc => doc.FileName == docAudit.Document.FileName &&
                    doc.ImageId == docAudit.Document.ImageId &&
                    doc.ImageTypeId == docAudit.Document.ImageTypeId
                );
            }

            if (document != null) return document;

            {
                document = DocumentFactory.CreateEntity(workUnit,
                    documentId: docAudit.Document.DocumentId,
                    documentTypeId: (byte)docAudit.Document.DocumentTypeId,
                    fileName: docAudit.Document.FileName,
                    imageId: docAudit.Document.ImageId,
                    imageTypeId: docAudit.Document.ImageTypeId
                );
            }

            return document;
        }

        #endregion
    }
}