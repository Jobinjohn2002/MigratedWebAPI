using SynergyApplicationFrameworkApi.Application.DTOs.ContainerInstanceIdentifiers;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CreateContainerInstanceDataContract
    /// </summary>
    public class CreateContainerInstanceDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
        public int? PinReasonId;
        public int EventTypeId;
        public int ItemTypeId;
        public int? DefaultLocationId { get; set; }
        public bool IsIdentifiable;
        /// <summary>
        /// Gets or sets WeighingRequired
        /// </summary>
        public bool WeighingRequired { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        public bool PrintBarcode;
        public bool IsChargeable;
        public byte? QALabelDefinition;
        public byte? Linear1DBarcodeDefinition;
        public byte? DataMatrix2DBarcodeDefinition;
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifiers
        /// </summary>
        public List<ContainerInstanceIdentifierDataContract> ContainerInstanceIdentifiers { get; set; }
    }
}