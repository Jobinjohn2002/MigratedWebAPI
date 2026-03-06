using SynergyApplicationFrameworkApi.Application.DTOs.ItemExceptions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ItemExceptionHelper
    /// </summary>
    public class ItemExceptionHelper : TurnaroundEvents
    {
        public ItemExceptionHelper(SynergyTrakData data) : base(data)
        {
        }

        /// <summary>
        /// UpdateItemExceptionsList operation
        /// </summary>
        public void UpdateItemExceptionsList(IItemExceptions request, bool createTurnaroundEvent = true)
        {
            if (!request.TurnaroundId.HasValue)
            {
                throw new Exception("Cannot update ItemExceptions without a Turnaround!");
            }

            using (IUnitOfWork workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var itemExceptionRepository = ItemExceptionRepository.New(workUnit);

                itemExceptionRepository.UpdateItemExceptionsList(
                    request.ContainerInstanceId.Value,
                    request.TurnaroundId.Value,
                    request.UserId, 
                    request.ItemExceptions.Select(ie => new ItemExceptionGrouped
                    {
                        ContainerContentId = ie.ContainerContentId,
                        ItemExceptionQuantity = ie.ItemExceptionQuantity,
                        ItemExceptionReasonId = ie.ItemExceptionReason.ItemExceptionReasonId
                    }).ToList()
                );
            }

            if (createTurnaroundEvent)
            {
                ApplyEvent(new ApplyTurnaroundEventDetails(TurnAroundEventTypeIdentifier.ItemExceptionUpdated), (ScanDetails)request);
            }
        }
    }
}