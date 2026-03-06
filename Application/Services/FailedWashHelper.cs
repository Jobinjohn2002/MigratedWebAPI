using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class FailedWashHelper
    {
        /// <summary>
        /// RecordFailedWashDetails operation
        /// </summary>
        public static bool RecordFailedWashDetails(List<DirtyInstrument> dirtyInstruments, string notes, int turnaroundEveetId )
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var failedWashRepo = FailedWashRepository.New(workUnit);

                var failedWash = FailedWashFactory.CreateEntity(workUnit,
                    turnaroundEventId: turnaroundEveetId,
                    notes: notes
                );

                foreach (var instrument in dirtyInstruments)
                {
                    failedWash.FailedWashInstrument.Add(FailedWashInstrumentFactory.CreateEntity(workUnit,
                        itemMasterId: instrument.ItemMasterId,
                        quantity: instrument.Quantity
                    ));
                }

                failedWashRepo.Add(failedWash);
                failedWashRepo.Save();
            }
            return true;
        }
    }
}