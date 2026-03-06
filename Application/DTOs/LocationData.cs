using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class LocationData
    {

        public LocationData()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ItemMasterText
        /// </summary>
        public string ItemMasterText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ReferenceNo
        /// </summary>
        public string ReferenceNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets StockTransactionTypeId
        /// </summary>
        public byte StockTransactionTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets StockTransactionTypeText
        /// </summary>
        public string StockTransactionTypeText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ToLocationText
        /// </summary>
        public string ToLocationText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ToLocationId
        /// </summary>
        public int ToLocationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ItemCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ModifiedBy
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets Lft
        /// </summary>
        public int Lft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets Rgt
        /// </summary>
        public int Rgt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets TreeText
        /// </summary>
        public string TreeText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TreeId { get; set; }
        public int? ParentLeafId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets LocationPath
        /// </summary>
        public string LocationPath { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets ItemStatusId
        /// </summary>
        public int ItemStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets LocationCodePath
        /// </summary>
        public string LocationCodePath { get; set; }
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }
        /// <summary>
        /// Gets or sets AssignedStations
        /// </summary>
        public List<StationData> AssignedStations { get; set; }
    }
}
