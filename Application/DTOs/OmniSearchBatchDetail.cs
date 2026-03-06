using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OmniSearchBatchDetail
    /// </summary>
    public class OmniSearchBatchDetail
    {
          public OmniSearchBatchDetail()
          { }

          public OmniSearchBatchDetail(int batchId,
                                    string externalId,
                                    string cycleTypeName,
                                    DateTime creationDate,
                                    bool isArchived
                                  )
        {
              BatchId = batchId;
              CycleTypeName = cycleTypeName;
              ExternalId = externalId;
              CreationDate = creationDate;
              IsArchived = isArchived;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        public string ExternalId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Cycle Type Name .
        /// </summary>
        /// <value>The Cycle Type Name.</value>
        /// <remarks></remarks>
        public string CycleTypeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the batch id.
        /// </summary>
        /// <value>The batch id.</value>
        /// <remarks></remarks>
        public int BatchId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        /// <remarks></remarks>
        public DateTime CreationDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }
        #endregion
    }
}
