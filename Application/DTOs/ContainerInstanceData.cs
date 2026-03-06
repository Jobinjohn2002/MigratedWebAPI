using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class ContainerInstanceData
    {
        public ContainerInstanceData()
        {
        }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets UsingCustomerName
        /// </summary>
        public string UsingCustomerName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }
        public int? BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        public int? LastTurnaroundId { get; set; }
        public int? LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeName
        /// </summary>
        public string LastEventTypeName { get; set; }
        public DateTime? LastEventCreatedDate { get; set; }
        /// <summary>
        /// Gets or sets LastTurnaroundExternalId
        /// </summary>
        public string LastTurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserName
        /// </summary>
        public string CreatedUserName { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserName
        /// </summary>
        public string ArchivedUserName { get; set; }
        /// <summary>
        /// Gets or sets IsInProduction
        /// </summary>
        public bool IsInProduction { get; set; }
        public short? QALabelProductCode { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public int MachineTypeId { get; set; }
        public int? ContainerMasterStockLocationId { get; set; }
        /// <summary>
        /// Gets or sets ComponentCount
        /// </summary>
        public int ComponentCount { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        public DateTime? LastLabelPrinted { get; set; }
        /// <summary>
        /// Gets or sets LastLabelPrintedUserName
        /// </summary>
        public string LastLabelPrintedUserName { get; set; }
        /// <summary>
        /// Gets or sets LoanSetRecordExternalId
        /// </summary>
        public string LoanSetRecordExternalId { get; set; }
        /// <summary>
        /// Gets or sets LoanSetRecordId
        /// </summary>
        public int LoanSetRecordId { get; set; }
        /// <summary>
        /// Gets or sets PrimaryId
        /// </summary>
        public string PrimaryId { get; set; }
        /// <summary>
        /// Gets or sets Identifiers
        /// </summary>
        public List<ContainerInstanceIdentifierData> Identifiers { get; set; }

    }
}
