using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.DTOs;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IPathwayRepository
    /// </summary>
    public interface IPathwayRepository : IDisposable
    {
        OperativeModelContainer Container { get; }
        IDataManager DataManager { get; }
    }
}