using System;
using System.Collections.Generic;
//using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Application.DTOs;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ContainerInstanceAutomaticEventService
    /// </summary>
    public class ContainerInstanceAutomaticEventService
    {
        AutomaticEvent _automaticEvent;

        public ContainerInstanceAutomaticEventService()
        {
            _automaticEvent = new AutomaticEvent();
        }

        /// <summary>
        /// Create operation
        /// </summary>
        public int Create(CreateAutomaticEventRuleRequest request, IPathwayRepository repository)
        {
            if (repository is null)
                throw new ArgumentNullException(nameof(IPathwayRepository));

            return _automaticEvent.Create(request, query =>
                 repository.DataManager.ExecuteNonQuery(query.Text, query.Type, query.Parameters.Select(param => new SqlParameter(param.Name, param.Value)).ToArray()));
        }

        /// <summary>
        /// Read operation
        /// </summary>
        public List<AutomaticEventDetailsDataContract> Read(ReadAutomaticEventRuleRequest request, IPathwayRepository repository)
        {
            if (repository is null)
                throw new ArgumentNullException(nameof(IPathwayRepository));

            var data = _automaticEvent.Read(request, query =>
                 repository.DataManager.ExecuteQuery(query.Text, query.Type, query.Parameters.Select(param => new SqlParameter(param.Name, param.Value)).ToArray()));

            return data.Select(d => new AutomaticEventDetailsDataContract
            {
                ContainerInstanceAutomaticEventId = d.ContainerInstanceAutomaticEventId,
                ContainerInstanceId = d.ContainerInstanceId,
                EventToApplyId = d.EventToApplyId,
                Created = d.Created,
                CreatedUserId = d.CreatedUserId,
                Text = d.Text,
                TriggerEvents = ConvertTriggerEventsToContract(d.TriggerEvents),
                Properties = d.Properties
            }).ToList();
        }

        /// <summary>
        /// Update operation
        /// </summary>
        public int Update(List<UpdateAutomaticEventRuleRequest> requestList, IPathwayRepository repository)
        {
            if (repository is null)
                throw new ArgumentNullException(nameof(IPathwayRepository));

            return _automaticEvent.Update(requestList, query =>
                repository.DataManager.ExecuteNonQuery(query.Text, query.Type, query.Parameters.Select(param => new SqlParameter(param.Name, param.Value)).ToArray()));
        }

        private List<AutomaticEventTriggerEventDetails> ConvertTriggerEventsToContract(List<AutomaticEventSummaryTriggerEvent> autoEventTriggerEvents)
        {
            return autoEventTriggerEvents.Select(x => new AutomaticEventTriggerEventDetails
            {
                Activated = x.Activated,
                EventTypeId = x.EventTypeId
            }).ToList();
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {
        }
    }
}