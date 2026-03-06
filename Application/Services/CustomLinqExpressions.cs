using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class CustomLinqExpressions
    {
        /// <summary>
        /// ContainerInstanceHasPrimaryId operation
        /// </summary>
        public static Expression<Func<ContainerInstance, bool>> ContainerInstanceHasPrimaryId(string primaryId)
        {
            return (c) => c.ContainerInstanceIdentifier.FirstOrDefault(i => i.IsPrimary && i.Value == primaryId) != null;
        }

        /// <summary>
        /// ContainerInstanceHasPrimaryId operation
        /// </summary>
        public static Expression<Func<ContainerInstance, bool>> ContainerInstanceHasPrimaryId(string primaryId, int facilityId)
        {
            return (c) => c.ContainerInstanceIdentifier.FirstOrDefault(i => i.IsPrimary && i.Value == primaryId) != null
                && c.FacilityId == facilityId;
        }

        /// <summary>
        /// TurnaroundContainerInstanceHasPrimaryId operation
        /// </summary>
        public static Expression<Func<Turnaround, bool>> TurnaroundContainerInstanceHasPrimaryId(string primaryId)
        {
            return (t) => t.ContainerInstance.ContainerInstanceIdentifier.FirstOrDefault(i => i.IsPrimary && i.Value == primaryId) != null;
        }

        /// <summary>
        /// TurnaroundContainerInstanceHasPrimaryId operation
        /// </summary>
        public static Expression<Func<Turnaround, bool>> TurnaroundContainerInstanceHasPrimaryId(string primaryId, int facilityId)
        {
            return (t) => t.ContainerInstance.ContainerInstanceIdentifier.FirstOrDefault(i => i.IsPrimary && i.Value == primaryId) != null
                && t.ContainerInstance.FacilityId == facilityId;
        }
    }
}
