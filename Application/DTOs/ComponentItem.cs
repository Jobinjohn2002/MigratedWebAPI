using SynergyApplicationFrameworkApi.Application.DTOs.ItemExceptions;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ComponentItem
    /// </summary>
    public class ComponentItem
    {
        /// <summary>
        /// Gets or sets CategoryGrouping
        /// </summary>
        public string CategoryGrouping { get; set; }
        public int? ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        public int? ComponentPartCount { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }
        public int? ContainerContentNoteId { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentNote
        /// </summary>
        public string ContainerContentNote { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterType
        /// </summary>
        public string ItemMasterType { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentId
        /// </summary>
        public int ContainerContentId { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets IsNote
        /// </summary>
        public bool IsNote { get; set; }
        public int? ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets GroupHeader
        /// </summary>
        public string GroupHeader { get; set; }
        /// <summary>
        /// Gets or sets IsItemContainsImage
        /// </summary>
        public bool IsItemContainsImage { get; set; }
        /// <summary>
        /// Gets or sets IsItemContainsDocument
        /// </summary>
        public bool IsItemContainsDocument { get; set; }
        /// <summary>
        /// Gets or sets ItemInstances
        /// </summary>
        public List<ItemInstanceDataContract> ItemInstances { get; set; }
        /// <summary>
        /// Gets or sets DirtyInstrument
        /// </summary>
        public DirtyInstrument DirtyInstrument { get; set; }
        /// <summary>
        /// Gets or sets Manufacturer
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Gets or sets ManufacturerRef
        /// </summary>
        public string ManufacturerRef { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptions
        /// </summary>
        public List<ItemExceptionDataContract> ItemExceptions { get; set; }
    }
}