using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Master Parameters Data
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// MasterParametersData
    /// </summary>
    public class MasterParametersData
    {
        public MasterParametersData() { }

        public MasterParametersData(short? itemTypeId, short? facilityId, string externalId, string baseType, string subType, string text, DataFilter dataFilter, string customerName) 
        {
            ItemTypeId = itemTypeId;
            FacilityId = facilityId;
            ExternalId = externalId;
            BaseItemTypeName = baseType;
            ChildItemTypeName = subType;
            Text = text;
            PagingSortingFilters = dataFilter;
            CustomerName = customerName;
        }
        public short? ItemTypeId { get; set; }
        public short? ParentItemTypeId { get; set; }
        public short? FacilityId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets PagingSortingFilters
        /// </summary>
        public DataFilter PagingSortingFilters { get; set; }
        public string SearchCriteriaText{get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
    }
}