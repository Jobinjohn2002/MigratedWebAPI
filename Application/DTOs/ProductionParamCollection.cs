using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProductionParamCollection
    /// </summary>
    public class ProductionParamCollection
    {
        
        #region Constructor

        public ProductionParamCollection()
        {

        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <param name="productionEventTypeId"></param>
        /// <param name="lastProcessEventTypeId"></param>
        /// <param name="baseItemTypeId"></param>
        /// <param name="serviceRequirementDefinitionId"></param>
        /// <param name="filter"></param>
        /// <param name="overDue"></param>
        public ProductionParamCollection(int facilityId, string customerDefinitionId, int? productionEventTypeId, int? lastProcessEventTypeId, int? baseItemTypeId, int? serviceRequirementDefinitionId, DataFilter filter, bool? overDue)
        {
            FacilityId = facilityId;
            CustomerDefinitionId = customerDefinitionId;
            ProductionEventTypeId = productionEventTypeId;
            LastProcessEventTypeId = lastProcessEventTypeId;
            BaseItemTypeId = baseItemTypeId;
            ServiceRequirementDefinitionId = serviceRequirementDefinitionId;
            Filter = filter;
            OverDue = overDue;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <param name="productionEventTypeId"></param>
        /// <param name="lastProcessEventTypeId"></param>
        /// <param name="baseItemTypeId"></param>
        /// <param name="serviceRequirementDefinitionId"></param>
        /// <param name="filter"></param>
        /// <param name="overDue"></param>
        public ProductionParamCollection(int facilityId, short? alternateFacilityId, string customerDefinitionId, int? productionEventTypeId, int? lastProcessEventTypeId, int? baseItemTypeId, int? serviceRequirementDefinitionId, DataFilter filter, bool? overDue)
            : this(facilityId, customerDefinitionId, productionEventTypeId, lastProcessEventTypeId, baseItemTypeId, serviceRequirementDefinitionId, filter, overDue)
        {
            AlternateFacilityId = alternateFacilityId;
        }

        #endregion

        #region Public Members
        /// <summary>
        /// Facility id
        /// </summary>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Customer Definition Id
        /// </summary>
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public string CustomerDefinitionId { get; set; }
        /// <summary>
        /// Production Event Type Id
        /// </summary>
        public int? ProductionEventTypeId { get; set; }
        /// <summary>
        /// Last Process Event TypeId
        /// </summary>
        public int? LastProcessEventTypeId { get; set; }
        /// <summary>
        /// Base Item Type Id
        /// </summary>
        public int? BaseItemTypeId { get; set; }
        /// <summary>
        /// Service Requirement Definition Id
        /// </summary>
        public int? ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Filter
        /// </summary>
        /// <summary>
        /// Gets or sets Filter
        /// </summary>
        public DataFilter Filter { get; set; }
        /// <summary>
        /// Over due
        /// </summary>
        public bool? OverDue { get; set; }
        /// <summary>
        /// Expired item count
        /// </summary>
        /// <summary>
        /// Gets or sets ExpiredItemsCount
        /// </summary>
        public int ExpiredItemsCount { get; set; }
        /// <summary>
        /// Near expiry item count
        /// </summary>
        /// <summary>
        /// Gets or sets NearExpiryItemsCount
        /// </summary>
        public int NearExpiryItemsCount { get; set; }

        /// <summary>
        /// Alternate processing facilityId 
        /// </summary>
        public short? AlternateFacilityId { get; set; }

        /// <summary>
        /// Facility Name
        /// </summary>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        public bool? IsIdentifiable { get; set; }

        /// <summary>
        /// Gets or sets useMFP
        /// </summary>
        public bool useMFP { get; set; }

        /// <summary>
        /// Gets or sets UseEventContext
        /// </summary>
        public bool UseEventContext { get; set; }

        public bool? IncludeAlternateFacilityItems { get; set; }

        #endregion
    }
}
