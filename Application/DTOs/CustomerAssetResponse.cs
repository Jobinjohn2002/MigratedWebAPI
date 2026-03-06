using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// The response which contains a list of customer assets
    /// </summary>
    /// <summary>
    /// CustomerAssetResponse
    /// </summary>
    public class CustomerAssetResponse
    {
        /// <summary>
        /// Customer assets
        /// </summary>
        /// <summary>
        /// Gets or sets CustomerAssets
        /// </summary>
        public List<CustomerAssetInfo> CustomerAssets { get; set; }
    }

    /// <summary>
    /// The information defined within a customer asset
    /// </summary>
    /// <summary>
    /// CustomerAssetInfo
    /// </summary>
    public class CustomerAssetInfo
    {
        /// <summary>
        /// ContainerMasterId to get batch cycles
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        /// <summary>
        /// ContainerInstanceId to get instance identifiers
        /// </summary> 
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// Container Instance Primary Identifier Value
        /// </summary>
        /// <summary>
        /// Gets or sets AssetNumber
        /// </summary>
        public string AssetNumber { get; set; }

        /// <summary>
        /// The container master External ID, not product number
        /// </summary>
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }

        /// <summary>
        /// the container master "modified date", the container master is created upon alteration of the container master definition
        /// </summary>
        public DateTime? ProductModifiedDate { get; set; }

        /// <summary>
        /// the date time when the container instance was created
        /// </summary>
        public DateTime? AssetCreatedDate { get; set; }

        /// <summary>
        /// Container Master Text
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Container Master Machine Type Text
        /// </summary>
        /// <summary>
        /// Gets or sets MachineType
        /// </summary>
        public string MachineType { get; set; }

        /// <summary>
        /// Container Master Item Type Text
        /// </summary>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Container Master Speciality Text
        /// </summary>
        /// <summary>
        /// Gets or sets Speciality
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Container Master ContainerMasterProcessingBatchCycle table batch cycles
        /// </summary>
        /// <summary>
        /// Gets or sets BatchCycles
        /// </summary>
        public List<BatchCycle> BatchCycles { get; set; }

        /// <summary>
        /// If the container instance is archived or not (might not matter as they are archived upon container master archiving)
        /// </summary>
        /// <summary>
        /// Gets or sets AssetActive
        /// </summary>
        public bool AssetActive { get; set; }

        /// <summary>
        /// Container master archived or not, should match asset
        /// </summary>
        /// <summary>
        /// Gets or sets ProductActive
        /// </summary>
        public bool ProductActive { get; set; }
    }

    /// <summary>
    /// Batch Cycle
    /// </summary>
    /// <summary>
    /// BatchCycle
    /// </summary>
    public class BatchCycle
    {
        #region serializable
        /// <summary>
        /// Batch Cycle Value
        /// </summary>
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        #endregion
    }

    /// <summary>
    /// Wrapper for result parameters
    /// </summary>
    /// <summary>
    /// ResultParameterModel
    /// </summary>
    public class ResultParameterModel
    {
        /// <summary>
        /// start of date range for result set
        /// </summary>
        public DateTime? start { get; set; }
        /// <summary>
        /// end of date range for result set
        /// </summary>
        public DateTime? end { get; set; }
        /// <summary>
        /// the results to skip
        /// </summary>
        public int? skip { get; set; }
        /// <summary>
        /// the maximum amount of results to return
        /// </summary>
        public int? max { get; set; }
    }
}
