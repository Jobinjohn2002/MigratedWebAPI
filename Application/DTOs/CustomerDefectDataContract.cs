using SynergyApplicationFrameworkApi.Application.DTOs.ItemExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectDataContract
    /// </summary>
    public class CustomerDefectDataContract : ScanDetails, IItemExceptions
    {
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public string CustomerId { get; set; }
        public int? ContainerMasterId { get; set; }
        public int? ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets DefectReasons
        /// </summary>
        public List<CustomerDefectReasonDataContract> DefectReasons { get; set; }
        /// <summary>
        /// Gets or sets InternalNoteText
        /// </summary>
        public string InternalNoteText { get; set; }
        /// <summary>
        /// Gets or sets DetailNoteText
        /// </summary>
        public string DetailNoteText { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptions
        /// </summary>
        public List<ItemExceptionDataContract> ItemExceptions { get; set; }
        /// <summary>
        /// Gets or sets HasMadeItemExceptionChanges
        /// </summary>
        public bool HasMadeItemExceptionChanges { get; set; }
        /// <summary>
        /// Gets or sets Quarantine
        /// </summary>
        public bool Quarantine { get; set; }
        /// <summary>
        /// Gets or sets WithEmail
        /// </summary>
        public bool WithEmail { get; set; }
        public int? ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectStatusId
        /// </summary>
        public byte CustomerDefectStatusId { get; set; }
        /// <summary>
        /// Gets or sets IsPreWash
        /// </summary>
        public bool IsPreWash { get; set; }
    }
}
