using SynergyApplicationFrameworkApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Interface defines an exception handler that implements the
    /// Exception Shielding pattern, increasing security at the Service Boundaries.
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IServiceExceptionManager
    /// </summary>
    public interface IServiceExceptionManager : IPathwayExceptionManager
    {
    }
}