using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StockRequest
    /// </summary>
    public class StockRequest
    {
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Required
        /// </summary>
        public int Required { get; set; }
    }

    /// <summary>
    /// StockForecast
    /// </summary>
    public class StockForecast
    {
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Required
        /// </summary>
        public int Required { get; set; }
        /// <summary>
        /// Gets or sets Ordered
        /// </summary>
        public int Ordered { get; set; }
        /// <summary>
        /// Gets or sets Instances
        /// </summary>
        public int Instances { get; set; }
        /// <summary>
        /// Gets or sets BaseTypeId
        /// </summary>
        public short BaseTypeId { get; set; }
        /// <summary>
        /// IsUnlimited operation
        /// </summary>
        public bool IsUnlimited()
        {
            return BaseTypeId == (short)KnownItemType.Extra;
        }

        /// <summary>
        /// Check operation
        /// </summary>
        public int Check(int additionalOrders)
        {
            return Instances - (additionalOrders + Required + Ordered);
        }
    }
}
