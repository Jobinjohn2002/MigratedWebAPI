using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IContainerInstanceAutomaticEventService
    /// </summary>
    public interface IContainerInstanceAutomaticEventService : IDisposable
    {
        int Create(CreateAutomaticEventRuleRequest request, IPathwayRepository repository);
        List<AutomaticEventDetailsDataContract> Read(ReadAutomaticEventRuleRequest request, IPathwayRepository repository);
        int Update(List<UpdateAutomaticEventRuleRequest> requestList, IPathwayRepository repository);
    }
}