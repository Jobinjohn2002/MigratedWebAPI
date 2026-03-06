using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IPathwayWarehouseRepository
    /// </summary>
    public interface IPathwayWarehouseRepository : IDisposable
    {
        List<ProcessGroupMode> GetProcessGroupModes(string connectionString, Guid userId, int containerMasterDefinitionId);
        void SetProcessGroupModes(string connectionString, Guid userId, int containerMasterDefinitionId, List<ProcessGroupMode> modes);
    }
}
