using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IEntityData
    /// </summary>
    public interface IEntityData : IData
    {
        string EntityKeyValue { get; set; }
    }
}