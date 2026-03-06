using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Master Parameter Interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IMasterParameters
    /// </summary>
    public interface IMasterParameters
    {
        short? ItemTypeId { get; set; }
        short? FacilityId { get; set; }
        string ExternalId { get; set; }
        string BaseItemTypeName { get; set; }
        string ChildItemTypeName { get; set; }
        string Text { get; set; }
        string CustomerName { get; set; }
        DataFilter PagingSortingFilters { get; set; }
        string SearchCriteriaText { get; set; }
    }
}