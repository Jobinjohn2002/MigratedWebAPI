using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ContainerInstances
    /// </summary>
    public class ContainerInstances
    {
        /// <summary>
        /// SetInstanceQuarantineReason operation
        /// </summary>
        public static void SetInstanceQuarantineReason(int? containerInstanceId, short? eventTypeId, short? quarantineReasonId)
        {
            if (containerInstanceId.HasValue)
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    var instance = containerRepository.Get(containerInstanceId.Value);

                    if (instance != null)
                    {
                        instance.QuarantineEventTypeId = eventTypeId;
                        instance.QuarantineReasonId = quarantineReasonId;

                        containerRepository.Save();
                    }
                }
            }
        }

        /// <summary>
        /// SetMultipleInstanceQuarantineReasons operation
        /// </summary>
        public static void SetMultipleInstanceQuarantineReasons(List<int> containerInstanceIds, short? eventTypeId, short? quarantineReasonId)
        {
            if (containerInstanceIds != null)
            {
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    var instanceList = containerRepository.GetMultiple(containerInstanceIds);

                    foreach (var instance in instanceList)
                    {
                        instance.QuarantineEventTypeId = eventTypeId;
                        instance.QuarantineReasonId = quarantineReasonId;
                    }

                    containerRepository.Save();
                }
            }
        }
    }
}