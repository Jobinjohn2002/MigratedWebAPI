using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InspectionAndAssemblyStationData
    /// </summary>
    public class InspectionAndAssemblyStationData : StationDataBase
    {
        /// <summary>
        /// Gets or sets the defects.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public new IList<DefectData> Defects { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public new IList<TurnaroundNoteData> Notes { get; set; }

        /// <summary>
        /// Gets or sets the TurnaroundEventType Id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundEventTypeId
        /// </summary>
        public int TurnaroundEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsItemContainsImage
        /// </summary>
        public bool IsItemContainsImage { get; set; }
        /// <summary>
        /// Gets or sets IsItemContainsDocument
        /// </summary>
        public bool IsItemContainsDocument { get; set; }
        /// <summary>
        /// Gets or sets ItemException
        /// </summary>
        public IList<ItemExceptionData> ItemException { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionApprovalFlag
        /// </summary>
        public bool ItemExceptionApprovalFlag { get; set; } 

    }
}
