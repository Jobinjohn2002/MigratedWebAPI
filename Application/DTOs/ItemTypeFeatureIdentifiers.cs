using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemTypeFeatureIdentifier
    /// 0x1
    /// </summary>
    /// <remarks></remarks>
    [Flags]
    [Serializable]
    public enum ItemTypeFeatureIdentifiers
    {

        None = 0,

        AllowsCustomerCosts = 0x1,

        IPOHCount = 0x2,

        InstrumentCount = 0x4,

        FinancialComponentCount = 0x8,

        AllowBatchTag = 0x10,
        ///// <summary>
        ///// No additional features
        ///// </summary>

        ///// <summary>
        ///// Supports a tray list of sub products
        ///// </summary>

        ///// <summary>
        ///// Allow consumables on the tray list
        ///// </summary>

        ///// <summary>
        ///// Allow instruments on the tray list
        ///// </summary>

        ///// <summary>
        ///// External ID of the item is required
        ///// </summary>

        ///// <summary>
        ///// The item can have instances
        ///// </summary>

        ///// <summary>
        ///// The item can have non instance specific turn arounds
        ///// </summary>

        ///// <summary>
        ///// Item must have at least one delivery point assigned
        ///// </summary>

        ///// <summary>
        ///// A Tray List may be printed for this item's components
        ///// </summary>
        ///// <summary>
        ///// Allow drapes on the pack list
        ///// </summary>

        ///// <summary>
        ///// Allow bulk procerss using tags
        ///// </summary>

        ///// <summary>
        ///// Instrument allowed to migrate across trays
        ///// </summary>

        ///// <summary>
        ///// Instrument to be tracked
        ///// </summary>

        ///// <summary>
        ///// Print QA labels for each component on the item
        ///// </summary>

        ///// <summary>
        ///// Is Non Creatable Item
        ///// </summary>

        ///// <summary>
        ///// Feature 909- Delivered Goods
        ///// </summary>
    }
}