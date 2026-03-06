using SynergyApplicationFrameworkApi.Application.DTOs.Batch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ConfigurableListHelper
    /// </summary>
    public class ConfigurableListHelper
    {
        private IUnitOfWork _unitOfWork;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unitOfWork">An <see cref="IUnitOfWork"/> used for querying the database.</param>
        public ConfigurableListHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Machine Types
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IMachineType"/></returns>
        /// <summary>
        /// GetConfiguredMachineTypes operation
        /// </summary>
        public IQueryable<IMachineType> GetConfiguredMachineTypes(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.MachineType, facilityId);
            return list.Select(x => (MachineType)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Item Types
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IItemType"/></returns>
        /// <summary>
        /// GetConfiguredItemTypes operation
        /// </summary>
        public IQueryable<IItemType> GetConfiguredItemTypes(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.ItemType, facilityId);
            return list.Select(x => (ItemType)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Decontamination Tasks
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IDecontaminationTask"/></returns>
        /// <summary>
        /// GetConfiguredDecontaminationTasks operation
        /// </summary>
        public IQueryable<IDecontaminationTask> GetConfiguredDecontaminationTasks(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.DecontaminationTask, facilityId);
            return list.Select(x => (DecontaminationTask)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Batch Cycles
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IBatchCycle"/></returns>
        /// <summary>
        /// GetConfiguredBatchCycles operation
        /// </summary>
        public IQueryable<IBatchCycle> GetConfiguredBatchCycles(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.BatchCycle, facilityId);
            return list.Select(x => (BatchCycle)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Couriers
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="ICourier"/></returns>
        /// <summary>
        /// GetConfiguredCouriers operation
        /// </summary>
        public IQueryable<ICourier> GetConfiguredCouriers(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.Courier, facilityId);
            return list.Select(x => (Courier)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Maintenance Activities
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IMaintenanceActivity"/></returns>
        /// <summary>
        /// GetConfiguredMaintenanceActivities operation
        /// </summary>
        public IQueryable<IMaintenanceActivity> GetConfiguredMaintenanceActivities(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.MaintenanceActivity, facilityId);
            return list.Select(x => (MaintenanceActivity)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Specialities
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="ISpeciality"/></returns>
        /// <summary>
        /// GetConfiguredSpecialities operation
        /// </summary>
        public IQueryable<ISpeciality> GetConfiguredSpecialities(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.Speciality, facilityId);
            return list.Select(x => (Speciality)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Categories
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="ICategory"/></returns>
        /// <summary>
        /// GetConfiguredCategories operation
        /// </summary>
        public IQueryable<ICategory> GetConfiguredCategories(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.Category, facilityId);
            return list.Select(x => (Category)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Defect Responsibilities
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IDefectResponsibility"/></returns>
        /// <summary>
        /// GetConfiguredDefectResponsibilities operation
        /// </summary>
        public IQueryable<IDefectResponsibility> GetConfiguredDefectResponsibilities(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.DefectResponsibility, facilityId);
            return list.Select(x => (DefectResponsibility)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) ItemException Reasons
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IItemExceptionReason"/></returns>
        /// <summary>
        /// GetConfiguredItemExceptionReasons operation
        /// </summary>
        public IQueryable<IItemExceptionReason> GetConfiguredItemExceptionReasons(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.ItemExceptionReason, facilityId);
            return list.Select(x => (ItemExceptionReason)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Quarantine Reasons
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IQuarantineReason"/></returns>
        /// <summary>
        /// GetConfiguredQuarantineReasons operation
        /// </summary>
        public IQueryable<IQuarantineReason> GetConfiguredQuarantineReasons(int facilityId)
        {
            var list = GetConfigurableListObjects(ConfigurableListTypeIdentifier.QuarantineReason, facilityId);
            return list.Where(x => ((QuarantineReason)x).IsUserSelectable).Select(x => (QuarantineReason)x).AsQueryable();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Failure Reasons
        /// by event, for a facility, as setup in the FailureTypeEventType table.
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <param name="turnAroundEventType">The event type the reasons are for</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IFailureType"/></returns>
        /// <summary>
        /// GetFailureTypes operation
        /// </summary>
        public IQueryable<IFailureType> GetFailureTypes(int facilityId, TurnAroundEventTypeIdentifier turnAroundEventType)
        {
            var context = (OperativeModelContainer)_unitOfWork.Context;
            var baseQuery = GetBaseQuery(ConfigurableListTypeIdentifier.FailureTypeEventType, facilityId, context);

            var failureReasons = from cb in baseQuery
                                 join x in context.FailureTypeEventType.Where(f => f.EventTypeId == (int)turnAroundEventType) on cb.CustomValueId equals x.FailureTypeEventTypeId
                                 join ft in context.FailureType on x.FailureTypeId equals ft.FailureTypeId
                                 orderby cb.Order, ft.Text
                                 select ft;

            return failureReasons;
        }

        /// <summary>
        /// GetItemExceptionReasonById operation
        /// </summary>
        public IItemExceptionReason GetItemExceptionReasonById(int currentItemExceptionReasonId)
        {
            var context = (OperativeModelContainer)_unitOfWork.Context;

            return context.ItemExceptionReason.FirstOrDefault(mir => mir.ItemExceptionReasonId == currentItemExceptionReasonId) ?? ItemExceptionReasonFactory.CreateEntity(_unitOfWork);
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Itemtypes
        /// for a facility along with whether they are actually selected to be used.
        /// Used in Admin on Facility>ItemTypes tab
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <returns>A <see cref="List<>"/> of <see cref="FacilityItemTypeData"/></returns>
        /// <summary>
        /// GetConfiguredAssociatedItemTypes operation
        /// </summary>
        public IList<FacilityItemTypeData> GetConfiguredAssociatedItemTypes(int facilityId)
        {
            var context = (OperativeModelContainer)_unitOfWork.Context;
            var baseQuery = GetBaseQuery(ConfigurableListTypeIdentifier.ItemType, facilityId, context);
            var itemTypes = from cb in baseQuery
                            join it in context.ItemType on cb.CustomValueId equals it.ItemTypeId
                            join pit in context.ItemType on it.ParentItemTypeId equals pit.ItemTypeId
                            where it.ParentItemTypeId != null && it.Archived == null
                            join fit in context.FacilityItemType.Where(f => f.FacilityId == facilityId) on it.ItemTypeId equals fit.ItemTypeId into fits
                            from fit in fits.DefaultIfEmpty()
                            join sit in context.SterilisationExpiryTime.Where(s => s.FacilityId == facilityId && s.CustomerDefinitionId == null) on it.ItemTypeId equals sit.ItemTypeId into sits
                            from sit in sits.DefaultIfEmpty()

                            select new FacilityItemTypeData()
                            {
                                ItemTypeId = it.ItemTypeId,
                                ParentItemTypeId = (int)it.ParentItemTypeId,
                                ItemTypeName = it.Text,
                                ParentItemTypeName = pit.Text,
                                IsComponent = pit.IsComponent,
                                FacilityId = (short)facilityId,
                                ExpiryDays = sit.ExpiryDays,
                                Selected = fit == null ? false : true
                            };
            var parentItemTypes = (from cb in baseQuery
                                   join it in context.ItemType on cb.CustomValueId equals it.ItemTypeId
                                   where it.ParentItemTypeId == null && it.Archived == null
                                   join fit in context.FacilityItemType.Where(f => f.FacilityId == facilityId) on it.ItemTypeId equals fit.ItemTypeId into fits
                                   from fit in fits.DefaultIfEmpty()
                                   join sit in context.SterilisationExpiryTime.Where(s => s.FacilityId == facilityId && s.CustomerDefinitionId == null) on it.ItemTypeId equals sit.ItemTypeId into sits
                                   from sit in sits.DefaultIfEmpty()

                                   select new FacilityItemTypeData()
                                   {
                                       ItemTypeId = it.ItemTypeId,
                                       ParentItemTypeId = 0,
                                       ItemTypeName = it.Text,
                                       ParentItemTypeName = it.Text,
                                       IsComponent = it.IsComponent,
                                       FacilityId = (short)facilityId,
                                       ExpiryDays = sit.ExpiryDays,
                                       Selected = context.FacilityItemType.Where(f => f.FacilityId == facilityId && f.ItemType.ParentItemTypeId == it.ItemTypeId).Count() == 0 ? false
                                            : context.FacilityItemType.Where(f => f.FacilityId == facilityId && f.ItemType.ParentItemTypeId == it.ItemTypeId).Count()
                                            == itemTypes.Where(i => i.ParentItemTypeId == it.ItemTypeId).Count() ? true : (bool?)null
                                   });
            return parentItemTypes.Concat(itemTypes).OrderBy(i => i.ParentItemTypeName).ThenBy(i => i.ParentItemTypeId).ThenBy(i => i.ItemTypeName).ToList();
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by Configurable Lists database structure) Batch Cycles for a sterilser
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <param name="machineTypeId">The Machine Type id</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IBatchCycle"/></returns>
        /// <summary>
        /// GetConfiguredBatchCyclesForSteriliserMachineType operation
        /// </summary>
        public IQueryable<IBatchCycle> GetConfiguredBatchCyclesForSteriliserMachineType(int facilityId, int machineTypeId)
        {
            var context = (OperativeModelContainer)_unitOfWork.Context;
            var baseQuery = GetBaseQuery(ConfigurableListTypeIdentifier.BatchCycle, facilityId, context);
            var batchCycles = from cb in baseQuery
                              join bc in context.BatchCycle on cb.CustomValueId equals bc.BatchCycleId
                              join mt in context.MachineType.Where(m => m.IsSteriliser == true) on bc.MachineTypeId equals mt.MachineTypeId
                              where mt.MachineTypeId == machineTypeId
                              orderby cb.Order, bc.Text
                              select bc;

            return batchCycles;
        }

        /// <summary>
        /// Gets the configured (i.e. allowed by both Configurable Lists database structure AND selected in Admin) Batch Cycles for a machine
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <param name="machineId">The Machine id</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="IBatchCycle"/></returns>
        /// <summary>
        /// GetConfiguredBatchCyclesForMachine operation
        /// </summary>
        public IQueryable<BatchCycleDataContract> GetConfiguredBatchCyclesForMachine(int facilityId, int machineId)
        {
            var context = (OperativeModelContainer)_unitOfWork.Context;
            var baseQuery = GetBaseQuery(ConfigurableListTypeIdentifier.BatchCycle, facilityId, context);
            var batchCycles = (from cb in baseQuery
                              join bc in context.BatchCycle on cb.CustomValueId equals bc.BatchCycleId
                              join mbc in context.MachineBatchCycle.Where(m => m.MachineId == machineId) on bc.BatchCycleId equals mbc.BatchCycleId
                              orderby cb.Order, bc.Text

                              select new BatchCycleDataContract()
                              {
                                  CycleTypeId = bc.BatchCycleId,
                                  Name = bc.Text,
                                  IsChargeable = bc.IsChargeable,
                                  IsBiologicalIndicatorEnabled = mbc.BiologicalIndicatorEnabled ?? false
                              });

            return batchCycles;
        }

        /// <summary>
        /// Gets the the configured (i.e. allowed by both Configurable Lists database structure AND selected in Admin) Decontamination Tasks for a Container Master
        /// </summary>
        /// <param name="facilityId">The id of the Facility</param>
        /// <param name="containerMasterId">The Container Master Id</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="DecontaminationTaskDataContract"/></returns>
        /// <summary>
        /// GetConfiguredDecontaminationTasksForContainerMaster operation
        /// </summary>
        public List<DecontaminationTaskDataContract> GetConfiguredDecontaminationTasksForContainerMaster(int facilityId, int containerMasterId)
        {
            List<DecontaminationTaskDataContract> result = null;
            var context = (OperativeModelContainer)_unitOfWork.Context;
            var failureTypesForFacility = GetFailureTypes(facilityId, TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure).Select(a => a.FailureTypeId).ToList();
            var baseQuery = GetBaseQuery(ConfigurableListTypeIdentifier.DecontaminationTask, facilityId, context);
            var containerMaster = (from cm in context.ContainerMaster.Where(cm => cm.ContainerMasterId == containerMasterId)
                                   select cm).OrderByDescending(o => o.Revision).FirstOrDefault();

            if (containerMaster != null)
            {
                var containerMasterDeconTaskIds = containerMaster.ProcessingDecontaminationTasks.Select(d => d.DecontaminationTaskId);

                var deconTasks = from cb in baseQuery
                                 join d in context.DecontaminationTask.Where(dt => containerMasterDeconTaskIds.Contains(dt.DecontaminationTaskId)) on cb.CustomValueId equals d.DecontaminationTaskId
                                 orderby cb.Order
                                 select new
                                 {
                                     d.DecontaminationTaskId,
                                     d.Text,
                                     d.Task,
                                     cb.Order
                                 };

                result = deconTasks.ToList().Select(d => new DecontaminationTaskDataContract()
                {
                    DeconTaskId = d.DecontaminationTaskId,
                    Text = d.Text,
                    FailureTypes = d.Task.FailureTypeEventType.Where(ftet => failureTypesForFacility.Any(f => f == ftet.FailureTypeId)).Select(ftet => new DataValueDataContract { Id = ftet.FailureType.FailureTypeId, Value = ftet.FailureType.Text }).OrderBy(a => failureTypesForFacility.IndexOf((byte)a.Id)).ToList(),
                    Order = d.Order
                }).ToList();
            }

            return result;
        }

        /// <summary>
        /// GetAllConfigurableObjectsForFacility operation
        /// </summary>
        public ConfigurableListDataContract GetAllConfigurableObjectsForFacility(ConfigurableListTypeIdentifier listType, int facilityId, bool getArchivedValues = true)
        {
            using (var operativeWorkUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var tenancyRepository = TenancyRepository.New(operativeWorkUnit);
                var tenancyId = tenancyRepository.GetTenancyForFacility(facilityId).TenancyId;

                return GetAllConfigurableObjectsForTenancy(listType, tenancyId, getArchivedValues);
            }
        }

        /// <summary>
        /// Get all of the currently configured and all of the possible values that can be configured for a tenancy
        /// </summary>
        /// <param name="listType">The <see cref="ConfigurableListType"/> the customisable values are required for</param>
        /// <param name="tenancyId">The tenancy id we want to get all current and possible values for</param>
        /// <returns></returns>
        /// <summary>
        /// GetAllConfigurableObjectsForTenancy operation
        /// </summary>
        public ConfigurableListDataContract GetAllConfigurableObjectsForTenancy(ConfigurableListTypeIdentifier listType, int tenancyId, bool getArchivedValues = true)
        {
            List<ConfigurableListValueDataContract> result = null;

            var context = (OperativeModelContainer)_unitOfWork.Context;

            var baseQuery = GetBaseQueryForAllValuesForTenancy(listType, tenancyId, context);

            bool allowAlphabeticalSorting = false;
            switch (listType)
            {
                case ConfigurableListTypeIdentifier.MachineType:
                    var machineTypes = from cb in baseQuery
                                       from x in context.MachineType.Where(x => cb.CustomValueId == x.MachineTypeId)
                                       select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null
                                       };
                    result = machineTypes.ToList();
                    break;

                case ConfigurableListTypeIdentifier.ItemType:
                    var itemTypes = from cb in baseQuery
                                    join it in context.ItemType on cb.CustomValueId equals it.ItemTypeId
                                    join pit in context.ItemType on it.ParentItemTypeId equals pit.ItemTypeId
                                    where it.ParentItemTypeId != null && it.Archived == null
                                    select new ConfigurableListValueDataContract()
                                    {
                                        ConfigurableListValueId = cb.ConfigurableListValueId,
                                        CustomValueId = cb.CustomValueId,
                                        Text = it.Text,
                                        IsSelected = cb.IsSelected,
                                        Order = cb.Order,
                                        IsSystem = cb.IsSystem,
                                        ParentText = pit.Text,
                                        BatchCycleIsChargeable = null
                                    };

                    result = itemTypes.ToList();
                    allowAlphabeticalSorting = true;
                    break;

                case ConfigurableListTypeIdentifier.DecontaminationTask:
                    var deconTasks = from cb in baseQuery
                                     from x in context.DecontaminationTask
                                         .Where(x => cb.CustomValueId == x.DecontaminationTaskId)
                                     select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null };

                    if (getArchivedValues)
                    {
                        deconTasks = deconTasks.Concat(context.DecontaminationTask.Where(dt => dt.Archived != null)
                                      .Select(a => new ConfigurableListValueDataContract() { ConfigurableListValueId = 0, CustomValueId = a.DecontaminationTaskId, Text = a.Text, IsSelected = false, Order = 0, IsSystem = false, ParentText = null, BatchCycleIsChargeable = null }));
                    }

                    result = deconTasks.ToList();
                    break;

                case ConfigurableListTypeIdentifier.BatchCycle:
                    var batchCycles = from cb in baseQuery
                                      from x in context.BatchCycle
                                          .Where(x => cb.CustomValueId == x.BatchCycleId)
                                      select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = x.MachineType.Text, BatchCycleIsChargeable = x.IsChargeable };

                    if (getArchivedValues)
                    {
                        batchCycles = batchCycles.Concat(context.BatchCycle.Where(m => m.Archived != null)
                                       .Select(a => new ConfigurableListValueDataContract() { ConfigurableListValueId = 0, CustomValueId = a.BatchCycleId, Text = a.Text, IsSelected = false, Order = 0, IsSystem = false, ParentText = null, BatchCycleIsChargeable = a.IsChargeable }));
                    }

                    result = batchCycles.ToList();
                    break;

                case ConfigurableListTypeIdentifier.Courier:
                    var couriers = from cb in baseQuery
                                   from x in context.Courier
                                       .Where(x => cb.CustomValueId == x.CourierId)
                                   select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null };

                    if (getArchivedValues)
                    {
                        couriers = couriers.Concat(context.Courier.Where(c => c.Archived != null)
                                    .Select(a => new ConfigurableListValueDataContract() { ConfigurableListValueId = 0, CustomValueId = a.CourierId, Text = a.Text, IsSelected = false, Order = 0, IsSystem = false, ParentText = null, BatchCycleIsChargeable = null }));
                    }

                    result = couriers.ToList();
                    break;

                case ConfigurableListTypeIdentifier.MaintenanceActivity:
                    var maintenanceActivities = from cb in baseQuery
                                                from x in context.MaintenanceActivity
                                                    .Where(x => cb.CustomValueId == x.MaintenanceActivityId)
                                                select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = x.ExternalId, BatchCycleIsChargeable = null };

                    if (getArchivedValues)
                    {
                        maintenanceActivities = maintenanceActivities.Concat(context.MaintenanceActivity.Where(m => m.Archived != null)
                                                 .Select(a => new ConfigurableListValueDataContract() { ConfigurableListValueId = 0, CustomValueId = a.MaintenanceActivityId, Text = a.Text, IsSelected = false, Order = 0, IsSystem = false, ParentText = null, BatchCycleIsChargeable = null }));
                    }

                    result = maintenanceActivities.ToList();
                    break;

                case ConfigurableListTypeIdentifier.Speciality:
                    var specialities = from cb in baseQuery
                                       from x in context.Speciality
                                           .Where(x => cb.CustomValueId == x.SpecialityId)
                                       select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null };

                    if (getArchivedValues)
                    {
                        specialities = specialities.Concat(context.Speciality.Where(s => s.Archived != null)
                                         .Select(a => new ConfigurableListValueDataContract() { ConfigurableListValueId = 0, CustomValueId = a.SpecialityId, Text = a.Text, IsSelected = false, Order = 0, IsSystem = false, ParentText = null, BatchCycleIsChargeable = null }));
                    }
                    result = specialities.ToList();
                    break;

                case ConfigurableListTypeIdentifier.Category:
                    var categories = from cb in baseQuery
                                     from x in context.Category.Where(x => cb.CustomValueId == x.CategoryId)
                                     select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null };
                    result = categories.ToList();
                    break;

                case ConfigurableListTypeIdentifier.DefectResponsibility:
                    var defectResponsibilities = from cb in baseQuery
                                                 from x in context.DefectResponsibility.Where(x => cb.CustomValueId == x.DefectResponsibilityId)
                                                 select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null };
                    result = defectResponsibilities.ToList();
                    break;

                case ConfigurableListTypeIdentifier.ItemExceptionReason:
                    var ItemExceptionReasons = from cb in baseQuery
                                             from x in context.ItemExceptionReason.Where(x => cb.CustomValueId == x.ItemExceptionReasonId)
                                             select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null };
                    result = ItemExceptionReasons.ToList();
                    break;

                case ConfigurableListTypeIdentifier.QuarantineReason:
                    var quarantineReasons = from cb in baseQuery
                                            from x in context.QuarantineReason.Where(x => cb.CustomValueId == x.QuarantineReasonId)
                                            select new ConfigurableListValueDataContract() { ConfigurableListValueId = cb.ConfigurableListValueId, CustomValueId = cb.CustomValueId, Text = x.Text, IsSelected = cb.IsSelected, Order = cb.Order, IsSystem = cb.IsSystem, ParentText = null, BatchCycleIsChargeable = null };
                    result = quarantineReasons.ToList();
                    break;

                case ConfigurableListTypeIdentifier.FailureTypeEventType:
                    throw new NotSupportedException("FailureTypeEventType is not supported here. Use GetAllFailureTypesForTenancy(int tenancyId, TurnAroundEventTypeIdentifier turnAroundEventType) instead.");
            }

            result = result.OrderBy(r => r.Order).ThenBy(r => r.Text).ToList();

            var listDc = new ConfigurableListDataContract()
            {
                ConfigurableListTypeId = (int)listType,
                AllowCustomValues = context.ConfigurableListType.Single(clt => clt.ConfigurableListTypeId == (int)listType).AllowCustomValues,
                AllowAlphabeticalSorting = allowAlphabeticalSorting,
                ConfigurableListValues = result
            };

            return listDc;
        }

        /// <summary>
        /// GetAllFailureTypesForTenancy operation
        /// </summary>
        public ConfigurableListDataContract GetAllFailureTypesForTenancy(int tenancyId, TurnAroundEventTypeIdentifier turnAroundEventType)
        {
            List<ConfigurableListValueDataContract> result = null;
            var context = (OperativeModelContainer)_unitOfWork.Context;
            var baseQuery = GetBaseQueryForAllValuesForTenancy(ConfigurableListTypeIdentifier.FailureTypeEventType, tenancyId, context);

            switch (turnAroundEventType)
            {
                case TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure:
                    var deconFailureReasons = from cb in baseQuery
                                              join x in context.FailureTypeEventType.Where(f => f.EventTypeId == (int)turnAroundEventType) on cb.CustomValueId equals x.FailureTypeEventTypeId
                                              join ft in context.FailureType on x.FailureTypeId equals ft.FailureTypeId
                                              join dc in context.DecontaminationTask on x.TaskId equals dc.TaskId
                                              select new ConfigurableListValueDataContract()
                                              {
                                                  ConfigurableListValueId = cb.ConfigurableListValueId,
                                                  CustomValueId = cb.CustomValueId,
                                                  Text = ft.Text,
                                                  IsSelected = cb.IsSelected,
                                                  Order = cb.Order,
                                                  IsSystem = cb.IsSystem,
                                                  ParentText = dc.Text,
                                                  BatchCycleIsChargeable = null
                                              };

                    result = deconFailureReasons.ToList();
                    break;

                default:
                    var failureReasons = from cb in baseQuery
                                         join x in context.FailureTypeEventType.Where(f => f.EventTypeId == (int)turnAroundEventType) on cb.CustomValueId equals x.FailureTypeEventTypeId
                                         join ft in context.FailureType on x.FailureTypeId equals ft.FailureTypeId
                                         select new ConfigurableListValueDataContract()
                                         {
                                             ConfigurableListValueId = cb.ConfigurableListValueId,
                                             CustomValueId = cb.CustomValueId,
                                             Text = ft.Text,
                                             IsSelected = cb.IsSelected,
                                             Order = cb.Order,
                                             IsSystem = cb.IsSystem,
                                             ParentText = null,
                                             BatchCycleIsChargeable = null
                                         };

                    result = failureReasons.ToList();
                    break;
            }

            result = result.ToList().OrderBy(r => r.Order).ThenBy(r => r.Text).ToList();

            var listDc = new ConfigurableListDataContract()
            {
                ConfigurableListTypeId = (int)ConfigurableListTypeIdentifier.FailureTypeEventType,
                EventTypeId = (int)turnAroundEventType,
                ConfigurableListValues = result
            };

            return listDc;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Gets a generic Configurable List
        /// </summary>
        /// <param name="listType">The <see cref="ConfigurableListType"/> the values are required for</param>
        /// <param name="facilityId">The Id of the facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="object"/></returns>
        private IQueryable<object> GetConfigurableListObjects(ConfigurableListTypeIdentifier listType, int facilityId)
        {
            IQueryable<object> result = null;
            var listObjects = GetConfigurableObjects(listType, facilityId);

            switch (listType)
            {
                case ConfigurableListTypeIdentifier.MachineType:
                    result = listObjects.Select(x => (MachineType)x);
                    break;

                case ConfigurableListTypeIdentifier.ItemType:
                    result = listObjects.Select(x => (ItemType)x);
                    break;

                case ConfigurableListTypeIdentifier.DecontaminationTask:
                    result = listObjects.Select(x => (DecontaminationTask)x);
                    break;

                case ConfigurableListTypeIdentifier.BatchCycle:
                    result = listObjects.Select(x => (BatchCycle)x);
                    break;

                case ConfigurableListTypeIdentifier.Courier:
                    result = listObjects.Select(x => (Courier)x);
                    break;

                case ConfigurableListTypeIdentifier.MaintenanceActivity:
                    result = listObjects.Select(x => (MaintenanceActivity)x);
                    break;

                case ConfigurableListTypeIdentifier.Speciality:
                    result = listObjects.Select(x => (Speciality)x);
                    break;

                case ConfigurableListTypeIdentifier.Category:
                    result = listObjects.Select(x => (Category)x);
                    break;

                case ConfigurableListTypeIdentifier.DefectResponsibility:
                    result = listObjects.Select(x => (DefectResponsibility)x);
                    break;

                case ConfigurableListTypeIdentifier.ItemExceptionReason:
                    result = listObjects.Select(x => (ItemExceptionReason)x);
                    break;

                case ConfigurableListTypeIdentifier.QuarantineReason:
                    result = listObjects.Select(x => (QuarantineReason)x);
                    break;

                case ConfigurableListTypeIdentifier.FailureTypeEventType:
                    throw new NotSupportedException("FailureTypeEventType not supported here. Use GetFailureTypes(int facilityId, TurnAroundEventTypeIdentifier turnAroundEventType) instead.");
            }

            return result;
        }

        /// <summary>
        /// Gets a generic Configurable List by joining the base query to the actual table containing the values we want.
        /// </summary>
        /// <param name="listType">The <see cref="ConfigurableListType"/> the values are required for</param>
        /// <param name="facilityId">The Id of the facility</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="object"/></returns>
        private IQueryable<object> GetConfigurableObjects(ConfigurableListTypeIdentifier listType, int facilityId)
        {
            IQueryable<object> result = null;

            var context = (OperativeModelContainer)_unitOfWork.Context;
            var baseQuery = GetBaseQuery(listType, facilityId, context);
            switch (listType)
            {
                case ConfigurableListTypeIdentifier.MachineType:
                    var machineTypes = from cb in baseQuery
                                       join x in context.MachineType on cb.CustomValueId equals x.MachineTypeId
                                       orderby cb.Order
                                       select x;
                    result = machineTypes;
                    break;

                case ConfigurableListTypeIdentifier.ItemType:
                    var itemTypes = from cb in baseQuery
                                    join x in context.ItemType on cb.CustomValueId equals x.ItemTypeId
                                    orderby cb.Order
                                    select x;
                    result = itemTypes;
                    break;

                case ConfigurableListTypeIdentifier.DecontaminationTask:
                    var deconTasks = from cb in baseQuery
                                     join x in context.DecontaminationTask on cb.CustomValueId equals x.DecontaminationTaskId
                                     orderby cb.Order
                                     select x;
                    result = deconTasks;
                    break;

                case ConfigurableListTypeIdentifier.BatchCycle:
                    var batchCycles = from cb in baseQuery
                                      join x in context.BatchCycle on cb.CustomValueId equals x.BatchCycleId
                                      orderby cb.Order
                                      select x;
                    result = batchCycles;
                    break;

                case ConfigurableListTypeIdentifier.Courier:
                    var couriers = from cb in baseQuery
                                   join x in context.Courier on cb.CustomValueId equals x.CourierId
                                   orderby cb.Order
                                   select x;
                    result = couriers;
                    break;

                case ConfigurableListTypeIdentifier.MaintenanceActivity:
                    var maintenanceActivities = from cb in baseQuery
                                                join x in context.MaintenanceActivity on cb.CustomValueId equals x.MaintenanceActivityId
                                                orderby cb.Order
                                                select x;
                    result = maintenanceActivities;
                    break;

                case ConfigurableListTypeIdentifier.Speciality:
                    var specialities = from cb in baseQuery
                                       join x in context.Speciality on cb.CustomValueId equals x.SpecialityId
                                       orderby cb.Order
                                       select x;
                    result = specialities;
                    break;

                case ConfigurableListTypeIdentifier.Category:
                    var categories = from cb in baseQuery
                                     join x in context.Category on cb.CustomValueId equals x.CategoryId
                                     orderby cb.Order
                                     select x;
                    result = categories;
                    break;

                case ConfigurableListTypeIdentifier.DefectResponsibility:
                    var defectResponsibilities = from cb in baseQuery
                                                 join x in context.DefectResponsibility on cb.CustomValueId equals x.DefectResponsibilityId
                                                 orderby cb.Order
                                                 select x;
                    result = defectResponsibilities;
                    break;

                case ConfigurableListTypeIdentifier.ItemExceptionReason:
                    var ItemExceptionReasons = from cb in baseQuery
                                             join x in context.ItemExceptionReason on cb.CustomValueId equals x.ItemExceptionReasonId
                                             orderby cb.Order
                                             select x;
                    result = ItemExceptionReasons;
                    break;

                case ConfigurableListTypeIdentifier.QuarantineReason:
                    var quarantineReasons = from cb in baseQuery
                                            join x in context.QuarantineReason on cb.CustomValueId equals x.QuarantineReasonId
                                            where x.IsUserSelectable == true
                                            orderby cb.Order
                                            select x;
                    result = quarantineReasons;
                    break;

                case ConfigurableListTypeIdentifier.FailureTypeEventType:
                    throw new NotSupportedException("FailureTypeEventType not supported here. Use GetFailureTypes(int facilityId, TurnAroundEventTypeIdentifier turnAroundEventType) instead.");
            }

            return result;
        }

        /// <summary>
        /// Basic query used for all configurable lists. Returns a query already limited to the list type
        /// and owner ready to be joined to the actual tables the values are in.
        /// </summary>
        /// <param name="listType">The <see cref="ConfigurableListType"/> the values are required for</param>
        /// <param name="facilityId">The Id of the facility</param>
        /// <param name="context">An <see cref="OperativeModelContainer"/> to use for the query.</param>
        /// <returns>An <see cref="IQueryable"/> collection of <see cref="CustomisableTableValue"/></returns>
        private IQueryable<ConfigurableListValueDataContract> GetBaseQuery(ConfigurableListTypeIdentifier listType, int facilityId, OperativeModelContainer context)
        {
            var tenancyOwnerIds = from f in context.Facility
                                  join o in context.Owner on f.OwnerId equals o.OwnerId
                                  join t in context.Tenancy on o.TenancyId equals t.TenancyId
                                  join ot in context.Owner on t.OwnerId equals ot.OwnerId
                                  where f.FacilityId == facilityId && t.OwnerId != null
                                  select ot.OwnerId;
            var facilityOwnerIds = from f in context.Facility
                                   where f.FacilityId == facilityId
                                   select f.OwnerId;

            var ownerIds = facilityOwnerIds.Concat(tenancyOwnerIds);
            var customBase = from ctv in context.ConfigurableListValue.Where(ctv => ctv.ConfigurableListTypeId == (int)listType)
                             from octv in context.OwnerConfigurableListValue.Where(octv => ownerIds.Contains(octv.OwnerId) && ctv.ConfigurableListValueId == octv.ConfigurableListValueId).DefaultIfEmpty()
                             where octv != null || ctv.IsSystem == true
                             select new ConfigurableListValueDataContract { ConfigurableListValueId = ctv.ConfigurableListValueId, CustomValueId = ctv.CustomValueId, Text = null, Order = octv.OrderId, IsSystem = ctv.IsSystem };

            return customBase;
        }

        private IQueryable<ConfigurableListValueDataContract> GetBaseQueryForAllValuesForTenancy(ConfigurableListTypeIdentifier listType, int tenancyId, OperativeModelContainer context)
        {
            var tenancyOwnerId = (from t in context.Tenancy
                                  join ot in context.Owner on t.OwnerId equals ot.OwnerId
                                  where t.TenancyId == tenancyId
                                  select ot.OwnerId).First();

            var customBase = from ctv in context.ConfigurableListValue.Where(ctv => ctv.ConfigurableListTypeId == (int)listType)
                             from octv in context.OwnerConfigurableListValue.Where(octv => octv.OwnerId == tenancyOwnerId && ctv.ConfigurableListValueId == octv.ConfigurableListValueId).DefaultIfEmpty()
                             select new ConfigurableListValueDataContract() { ConfigurableListValueId = ctv.ConfigurableListValueId, CustomValueId = ctv.CustomValueId, Text = null, IsSelected = octv != null, Order = octv != null ? octv.OrderId : 0, IsSystem = ctv.IsSystem, ParentText = null, BatchCycleIsChargeable = null };

            return customBase;
        }

        #endregion
    }
}