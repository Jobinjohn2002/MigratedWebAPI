using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IGenericKeyValue
    /// </summary>
    public interface IGenericKeyValue
    {
        int Id { get; set; }
        int? ParentId { get; set; }
        Guid UniqueIdentifier { get; set; }
        string Name { get; set; }
        string Tag { get; set; }
        string Status { get; set; }
    }
}
