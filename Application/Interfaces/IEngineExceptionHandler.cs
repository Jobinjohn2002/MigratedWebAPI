using SynergyApplicationFrameworkApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Pathway engine exception handling interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IEngineExceptionHandler
    /// </summary>
    public interface IEngineExceptionHandler : IPathwayExceptionHandler, IPathwayExceptionManager
    {
    }
}