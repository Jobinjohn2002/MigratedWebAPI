using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IServiceBase
    /// </summary>
    public interface IServiceBase : IDebugInfoAttachable, IDisposable
    {
        new DebugInfo Debug
        {
            get;
            set;
        }
    }
}
