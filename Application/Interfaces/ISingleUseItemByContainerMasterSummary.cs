using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ISingleUseItemByContainerMasterSummary
    /// </summary>
    public interface ISingleUseItemByContainerMasterSummary
    {
        string ExternalId { get; set; }

        string Name { get; set; }

        string ItemType { get; set; }

        int Quantity { get; set; }

        decimal BasePrice { get; set; }

        decimal Indexation { get; set; }
    }
}
