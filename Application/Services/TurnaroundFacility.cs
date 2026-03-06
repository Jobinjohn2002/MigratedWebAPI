using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// TurnaroundFacilityHelper
    /// </summary>
    public class TurnaroundFacilityHelper
    {
        /// <summary>
        /// Update operation
        /// </summary>
        public void Update(int turnaroundId, int scannedFacilityId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var tfRepository = TurnaroundFacilityRepository.New(workUnit);
                if (!tfRepository.All().Any(tf => tf.TurnaroundId == turnaroundId && tf.FacilityId == scannedFacilityId))
                {
                    var tf = TurnaroundFacilityFactory.CreateEntity(workUnit,
                        turnaroundId: turnaroundId,
                        facilityId: (short)scannedFacilityId
                    );

                    tfRepository.Add(tf);
                    tfRepository.Save();
                }
            }
        }

        /// <summary>
        /// Create operation
        /// </summary>
        public void Create(Turnaround newTurnaround)
        {
            {
                var tfRepository = TurnaroundFacilityRepository.New(workUnit);
                var primaryFacilityId = newTurnaround.ContainerMaster.ContainerMasterDefinition.CustomerDefinition.Customer.OrderByDescending(c => c.Revision).FirstOrDefault().FacilityId;
                var containerInstanceFacilityId = newTurnaround.ContainerInstance?.FacilityId ?? primaryFacilityId;
                TurnaroundFacility tf;

                if (newTurnaround.FacilityId != primaryFacilityId)
                {
                    tf = TurnaroundFacilityFactory.CreateEntity(workUnit,
                        turnaroundId: newTurnaround.TurnaroundId,
                        facilityId: primaryFacilityId
                    );

                    tfRepository.Add(tf);
                }
                tf = TurnaroundFacilityFactory.CreateEntity(workUnit,
                    turnaroundId: newTurnaround.TurnaroundId,
                    facilityId: newTurnaround.FacilityId
                );

                tfRepository.Add(tf);
                if (primaryFacilityId != containerInstanceFacilityId &&
                    newTurnaround.FacilityId != containerInstanceFacilityId)
                {
                    tf = TurnaroundFacilityFactory.CreateEntity(workUnit,
                        turnaroundId: newTurnaround.TurnaroundId,
                        facilityId: containerInstanceFacilityId
                    );

                    tfRepository.Add(tf);
                }

                tfRepository.Save();
            }
        }
    }
}