using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SynergyApplicationFrameworkApi.Framework.Container;
using SynergyApplicationFrameworkApi.Data.Models;
using SynergyApplicationFrameworkApi.Data.Repositories;
using SynergyApplicationFrameworkApi.Domain.Models;
using SynergyApplicationFrameworkApi.Framework;
using SynergyApplicationFrameworkApi.Application.Contracts;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// To add functionality for a new event, create a method in the Turnaround Event Methods region with params (ScanAssetDataContract scanDC, ScanDetails scanDetails)
    /// Add attribute and set to turnaround event type you wish to register for.
    /// Do not any methods in this or derived classes removed methods with 0 references, as they are referenced through reflection...
    /// </summary>
    /// <summary>
    /// TurnaroundEvents
    /// </summary>
    public class TurnaroundEvents
    {
        #region Fields

        protected SynergyTrakData? _data;
        protected ILog? Log;

        #endregion

        #region Constructor
        public TurnaroundEvents(SynergyTrakData data)
        {
            _data = data;
            Log = InstanceFactory.GetInstance<ILog>();
        }

        #endregion

        #region Public method

        /// <summary>
        /// Called externally to find the method that should process 'eventTypeId'
        /// </summary>
        /// <param name="eventTypeId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <summary>
        /// Create operation
        /// </summary>
        public static bool Create(TurnAroundEventTypeIdentifier eventTypeId, object data)
        {
            var derivedTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(TurnaroundEvents).IsAssignableFrom(t));

            foreach (var dt in derivedTypes)
            {
                var mi = dt.GetMethods().Where(m => m.GetCustomAttributes(typeof(ProcessTurnaroundEvent)).Any(ca => ((ProcessTurnaroundEvent)ca).EventType == eventTypeId)).FirstOrDefault();

                if (mi != null && data is SynergyTrakData)
                {
                    var obj = Activator.CreateInstance(dt, new object[] { ((SynergyTrakData)data) })!;
                    mi.Invoke(obj, new object[] { ((SynergyTrakData)data).ScanDC, ((SynergyTrakData)data).ScanDetails });

                    return true;
                }
            }

            return false;
        }

        #endregion

        #region ApplyEvent

        protected List<TurnaroundEventComplete> ApplyEvent(TurnAroundEventTypeIdentifier applyEventType, ScanAssetDataContract scanDC, ScanDetails scanDetails, bool isAutomaticEvent = false)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = applyEventType,
                    IsAutomaticEvent = isAutomaticEvent,
                    BatchId = scanDC.BatchId,
                    RemoveFromParent = scanDC.IsRemoveFromParent
                }
            };

            return ApplyEvent(eventsToApply, new List<ScanAssetDataContract>() { scanDC }, scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(TurnAroundEventTypeIdentifier applyEventType, ScanDetails scanDetails, bool isAutomaticEvent = false)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = applyEventType,
                    IsAutomaticEvent = isAutomaticEvent
                }
            };

            return ApplyEvent(eventsToApply, _data?.ScanDcList ?? new List<ScanAssetDataContract>(), scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(ApplyTurnaroundEventDetails eventToApply, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventToApply };

            return ApplyEvent(eventsToApply, new List<ScanAssetDataContract>() { scanDC }, scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(ApplyTurnaroundEventDetails eventToApply, ScanAssetDataContract scanDC, ScanDetails scanDetails, bool notificationsHandledExternally)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventToApply };
            return ApplyEvent(eventsToApply, new List<ScanAssetDataContract>() { scanDC }, scanDetails, notificationsHandledExternally);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(ApplyTurnaroundEventDetails eventToApply, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventToApply };

            return ApplyEvent(eventsToApply, _data?.ScanDcList ?? new List<ScanAssetDataContract>(), scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(ApplyTurnaroundEventDetails eventDetails, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventDetails };

            return ApplyEvent(eventsToApply, dataContracts, scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(ApplyTurnaroundEventDetails eventDetails, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails, bool notificationsHandledExternally)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventDetails };
            return ApplyEvent(eventsToApply, dataContracts, scanDetails, notificationsHandledExternally);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, ScanDetails scanDetails)
        {
            return ApplyEvent(eventsToApply, _data?.ScanDcList ?? new List<ScanAssetDataContract>(), scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            return ApplyEvent(eventsToApply, new List<ScanAssetDataContract>() { scanDC }, scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails)
        {
            return ApplyEvent(eventsToApply, dataContracts, scanDetails, false);
        }

        protected List<TurnaroundEventComplete> ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails, bool notificationsHandledExternally)
        {
            using (var applyEvent = InstanceFactory.GetInstance<IApplyEvent>())
            {
                applyEvent.Setup(_data);
                return applyEvent.ApplyEvents(eventsToApply, dataContracts, scanDetails, notificationsHandledExternally);
            }
        }

        #endregion

        #region Other Methods

        protected void UpdateContainerInstanceLocation(long? turnaroundExternalId, int? locationId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);

                if (turnaroundExternalId.HasValue)
                {
                    var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacilityId(turnaroundExternalId.Value, _data?.FacilityId ?? 0);
                    if (turnaround?.ContainerInstanceId.HasValue == true)
                    {
                        var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                        var containerInstance = containerInstanceRepository.Get(turnaround.ContainerInstanceId.Value);

                        if (containerInstance != null)
                        {
                            containerInstance.CurrentLocationId = locationId;
                            containerInstanceRepository.Save();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// CreateTurnaroundAssigned operation
        /// </summary>
        public void CreateTurnaroundAssigned(int turnaroundId, int parentTurnaroundId) => CreateTurnaroundAssigned(turnaroundId, parentTurnaroundId, false);

        /// <summary>
        /// CreateTurnaroundAssigned operation
        /// </summary>
        public void CreateTurnaroundAssigned(int turnaroundId, int parentTurnaroundId, bool forceCreateNew)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundAssignedRepository = TurnaroundAssignedRepository.New(workUnit);
                var turnaroundAssigned = TurnaroundAssignedFactory.CreateEntity(workUnit,
                    turnaroundParentId: parentTurnaroundId,
                    turnaroundChildId: turnaroundId
                );

                var taAlreadyExists = turnaroundAssignedRepository.Repository.Find(ta => ta.TurnaroundParentId == parentTurnaroundId && ta.TurnaroundChildId == turnaroundId).FirstOrDefault();

                if (taAlreadyExists == null)
                {
                    turnaroundAssignedRepository.Add(turnaroundAssigned);
                    workUnit.Save();
                }
                else if (forceCreateNew && taAlreadyExists != null)
                {
                    turnaroundAssignedRepository.Delete(taAlreadyExists);
                    turnaroundAssignedRepository.Add(turnaroundAssigned);
                    workUnit.Save();
                }
            }
        }

        protected void RemoveFromParent(ScanAssetDataContract scanDC)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundWhRepository = TurnaroundWHRepository.New(workUnit);
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.GetValueOrDefault());

                if (turnaround != null)
                {
                    turnaround.ParentTurnaroundId = null;
                    turnaroundRepository.Save();

                    var turnaroundWh = turnaroundWhRepository.GetByTurnaround(scanDC.TurnaroundId.GetValueOrDefault());

                    if (turnaroundWh != null)
                    {
                        turnaroundWh.ParentTurnaroundId = null;
                        turnaroundWhRepository.Save();
                    }
                }
            }

            scanDC.IsParentABatchTag = false;
            scanDC.IsParentACarriage = false;
            scanDC.ParentTurnaroundId = null;
        }

        #endregion
    }

    /// <summary>
    /// Attribute for marking methods with the relevant turnaround event type. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ProcessTurnaroundEvent : Attribute
    {
        private TurnAroundEventTypeIdentifier _eventType;

        public ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier eventType)
        {
            _eventType = eventType;
        }

        public TurnAroundEventTypeIdentifier EventType
        {
            get
            {
                return _eventType;
            }
            set
            {
                _eventType = value;
            }
        }
    }
}