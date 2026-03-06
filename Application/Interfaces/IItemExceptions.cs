using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IItemExceptions
    /// </summary>
    public interface IItemExceptions
    {
        List<ItemExceptionDataContract> ItemExceptions { get; set; }

        int? ContainerMasterDefinitionId { get; set; }

        int? ContainerInstanceId { get; set; }

        int? TurnaroundId { get; set; }

        int UserId { get; set; }
    }
}
