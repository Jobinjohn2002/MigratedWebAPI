using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class ItemExceptionRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public ItemException Get(int itemExceptionId)
        {
            return Repository.Find(itemException => itemException.ItemExceptionId == itemExceptionId).FirstOrDefault();
        }

        /// <summary>
        /// GetItemExceptionsByInstance operation
        /// </summary>
        public IQueryable<ItemException> GetItemExceptionsByInstance(int instanceId)
        {
            return Repository.Find(ie => ie.ContainerInstance.ContainerInstanceId == instanceId && ie.Archived == null);
        }

        /// <summary>
        /// GetItemExceptionsByTurnaround operation
        /// </summary>
        public IQueryable<ItemException> GetItemExceptionsByTurnaround(int turnaroundId)
        {
            return Repository.Find(ie => ie.Turnaround.TurnaroundId == turnaroundId && ie.Archived == null);
        }

        /// <summary>
        /// GetCustomerServiceItemExceptions operation
        /// </summary>
        public IQueryable<ItemException> GetCustomerServiceItemExceptions(int turnaroundId, int instanceId, int defectId)
        {
            var customerDefectRepository = CustomerDefectRepository.New(Repository.UnitOfWork);

            IEnumerable<ItemException> results;

            if ((instanceId == default(int)))
            {
                results =
                   (from ie in Repository.All()
                    join cd in customerDefectRepository.All() on ie.Turnaround.TurnaroundId equals cd.TurnaroundId
                    where ie.ContainerInstance.ContainerInstanceId == instanceId && ie.Created <= cd.Created && (ie.Archived ?? DateTime.UtcNow) > cd.Created
                    orderby ie.Created
                    select ie).AsEnumerable();
            }
            else
            {
                results =
                    (from ie in Repository.All()
                     join cd in customerDefectRepository.All() on ie.Turnaround.TurnaroundId equals cd.TurnaroundId
                     where cd.TurnaroundId == turnaroundId && ie.Created <= cd.Created && (ie.Archived ?? DateTime.UtcNow) > cd.Created
                     && cd.CustomerDefectId == defectId
                     orderby ie.Created
                     select ie).AsEnumerable();
            }

            return results.AsQueryable();
        }

        /// <summary>
        /// GetItemExceptionByInstanceAndItemAndTurnaround operation
        /// </summary>
        public ItemException GetItemExceptionByInstanceAndItemAndTurnaround(int instanceId, int itemMasterDefinitionId, int? turnaroundId)
        {
            if (turnaroundId == null)
            {
                return Repository.Find(
                    ie =>
                    ie.ContainerInstance.ContainerInstanceId == instanceId && ie.Archived == null &&
                    ie.ContainerContent.ItemMasterDefinitionId == itemMasterDefinitionId && ie.Turnaround == null).FirstOrDefault();
            }
            else
            {
                return
                    Repository.Find(
                        ie =>
                        ie.Turnaround.TurnaroundId == turnaroundId && ie.Archived == null &&
                        ie.ContainerContent.ItemMasterDefinitionId == itemMasterDefinitionId).FirstOrDefault();
            }
        }

        /// <summary>
        /// GetItemExceptionByInstanceAndItemWithoutTurnaround operation
        /// </summary>
        public ItemException GetItemExceptionByInstanceAndItemWithoutTurnaround(int instanceId, int itemMasterDefinitionId)
        {
            return Repository.Find(ie => ie.ContainerInstance.ContainerInstanceId == instanceId && ie.Archived == null && ie.ContainerContent.ItemMasterDefinitionId == itemMasterDefinitionId && ie.Turnaround == null).FirstOrDefault();
        }

        /// <summary>
        /// GetItemExceptionByInstanceAndItemWhereTurnaroundIsNull operation
        /// </summary>
        public IItemException GetItemExceptionByInstanceAndItemWhereTurnaroundIsNull(int instanceId, int itemMasterDefinitionId)
        {
            return Repository.Find(ie => ie.ContainerInstance.ContainerInstanceId == instanceId && ie.Archived == null && ie.ContainerContent.ItemMasterDefinitionId == itemMasterDefinitionId && ie.Turnaround == null).FirstOrDefault();
        }

        /// <summary>
        /// GetOldestItemExceptionByContainerContentAndReasonAndInstance operation
        /// </summary>
        public IItemException GetOldestItemExceptionByContainerContentAndReasonAndInstance(int instanceId, byte itemExceptionReasonId, int containerContentId)
        {
            return Repository.Find(ie => ie.ContainerInstance.ContainerInstanceId == instanceId
            && ie.Archived == null
            && ie.ContainerContentId == containerContentId
            && ie.ItemExceptionReasonId == itemExceptionReasonId).OrderByDescending(i => i.Created).FirstOrDefault();
        }

        /// <summary>
        /// GetOldestItemExceptionByContainerContentAndReasonAndTurnaround operation
        /// </summary>
        public IItemException GetOldestItemExceptionByContainerContentAndReasonAndTurnaround(int turnaroundId, byte itemExceptionReasonId, int containerContentId)
        {
            return Repository.Find(ie => ie.Turnaround.TurnaroundId == turnaroundId
            && ie.Archived == null
            && ie.ContainerContentId == containerContentId
            && ie.ItemExceptionReasonId == itemExceptionReasonId).OrderByDescending(i => i.Created).FirstOrDefault();
        }

        /// <summary>
        /// UpdateItemExceptionsList operation
        /// </summary>
        public void UpdateItemExceptionsList(int containerInstanceId, int? turnaroundId, int userId, List<ItemExceptionGrouped> updatedItemExceptions)
        {
            var turnaroundRepository = TurnaroundRepository.New(Repository.UnitOfWork);

            if (turnaroundId != null)
            {
                var turnaround = turnaroundRepository.Get(turnaroundId.Value);
                if (turnaround != null)
                {
                    var currentTurnaroundItemExceptions = GetItemExceptionsByTurnaround(turnaroundId.Value).ToList();
                    UpdateInner(false, containerInstanceId, turnaroundId, userId, updatedItemExceptions, currentTurnaroundItemExceptions);
                }
            }

            var currentContainerInstanceItemExceptions = GetItemExceptionsByInstance(containerInstanceId).ToList();
            UpdateInner(true, containerInstanceId, turnaroundId, userId, updatedItemExceptions, currentContainerInstanceItemExceptions);

            Repository.UnitOfWork.Save();
        }

        private void UpdateInner(bool containerLevelUpdate, int containerInstanceId, int? turnaroundId, int userId, List<ItemExceptionGrouped> updatedItemExceptions, List<ItemException> currentItemExceptions)
        {
            foreach (var currentException in currentItemExceptions.ToList())
            {
                if (!updatedItemExceptions.Any(
                    i => i.ContainerContentId == currentException.ContainerContentId
                    && i.ItemExceptionReasonId == currentException.ItemExceptionReasonId))
                {
                    currentException.Archived = DateTime.UtcNow;
                    currentException.ArchivedUserId = userId;
                }
            }

            foreach (var updatedItemException in updatedItemExceptions)
            {
                var existingExceptions = currentItemExceptions.Where(ie => ie.ContainerContentId == updatedItemException.ContainerContentId && ie.ItemExceptionReasonId == updatedItemException.ItemExceptionReasonId);

                if (existingExceptions != null && existingExceptions.Any())
                {
                    if (existingExceptions.Count() > updatedItemException.ItemExceptionQuantity)
                    {
                        existingExceptions.OrderBy(ie => ie.Created).Take(existingExceptions.Count() - updatedItemException.ItemExceptionQuantity).ToList().ForEach(ie =>
                        {
                            ie.Archived = DateTime.UtcNow;
                            ie.ArchivedUserId = userId;
                        });
                    }
                }
                var recordsToCreate = updatedItemException.ItemExceptionQuantity - existingExceptions?.Count() ?? 0;

                for (int i = 0; i < recordsToCreate; i++)
                {
                    CreateItemException(containerLevelUpdate, containerInstanceId, userId, updatedItemException.ContainerContentId, updatedItemException.ItemExceptionReasonId, turnaroundId);
                }
            }
        }

        private void CreateItemException(bool containerLevelUpdate, int containerInstanceId, int currentUserId, int containerContentId, byte itemExceptionReasonId, int? turnaroundId)
        {
            if (containerLevelUpdate)
            {
                var containerInstanceRepository = ContainerInstanceRepository.New(Repository.UnitOfWork);
                Add(new ItemException
                {
                    ContainerInstance = containerInstanceRepository.Get(containerInstanceId),
                    CreatedUserId = currentUserId,
                    ItemExceptionReasonId = itemExceptionReasonId,
                    ContainerContentId = containerContentId,
                    ItemInstanceId = null,
                    Created = DateTime.UtcNow,
                    Archived = null
                });
            }
            else
            {
                var turnaroundRepository = TurnaroundRepository.New(Repository.UnitOfWork);
                Add(new ItemException
                {
                    Turnaround = turnaroundRepository.Get(turnaroundId.Value),
                    CreatedUserId = currentUserId,
                    ItemExceptionReasonId = itemExceptionReasonId,
                    ContainerContentId = containerContentId,
                    ItemInstanceId = null,
                    Created = DateTime.UtcNow,
                    Archived = null
                });
            }
        }
    }
}