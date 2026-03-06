using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// Service Requirement Expiry Repository
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ServiceRequirementExpiryRepository
    /// </summary>
    public class ServiceRequirementExpiryRepository
    {
        /// <summary>
        /// ReadExpiryCalculation operation
        /// </summary>
        public IServiceRequirementExpiry ReadExpiryCalculation(int facilityId, int serviceRequirementId, int deliveryPointId, IUnitOfWork unit)
        {
            var expiry = new ServiceRequirementExpiry();

            expiry.Expiry = ((OperativeModelContainer)unit.Context).opsapp_ReadExpiryCalculation(facilityId, serviceRequirementId, deliveryPointId).FirstOrDefault().Value;
            
            return expiry;
        }

        /// <summary>
        /// Reads the expiry.
        /// </summary>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadExpiryCalculationWithTurnaround operation
        /// </summary>
        public IServiceRequirementExpiry ReadExpiryCalculationWithTurnaround(int serviceRequirementId, int turnaroundId, IUnitOfWork unit = null)
        {
            var expiry = new ServiceRequirementExpiry();

            if (unit == null)
            {
                using (var context = new OperativeModelContainer())
                {
                    foreach (var result in context.opsapp_ReadExpiryCalculationWithTurnaround(turnaroundId, serviceRequirementId))
                    {
                        expiry.Expiry = result.Value;
                    }
                }
            }
            else
            {
                foreach (var result in ((OperativeModelContainer)unit.Context).opsapp_ReadExpiryCalculationWithTurnaround(turnaroundId, serviceRequirementId))
                {
                    expiry.Expiry = result.Value;
                }
            }

            return expiry;
        }

        /// <summary>
        /// Reads the expiry.
        /// </summary>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadExpiryOutOfQuarantine operation
        /// </summary>
        public IServiceRequirementExpiry ReadExpiryOutOfQuarantine(int serviceRequirementId, int turnaroundId)
        {
            var expiry = new ServiceRequirementExpiry();
            {
                foreach (var result in context.admapp_ReadExpiryReCalculationQuarantine(turnaroundId, serviceRequirementId))
                {
                    expiry.Expiry = result.Value;

                }
                return expiry;
            }
        }

        /// <summary>
        /// Reads the expiry.
        /// </summary>
        /// <param name="oldServiceRequirementId">The old service requirement id.</param>
        /// <param name="newServiceRequirement">The new service requirement.</param>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="oldExpiry">The old expiry.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadExpiryReCalculation operation
        /// </summary>
        public IServiceRequirementExpiry ReadExpiryReCalculation(int turnaroundId, int oldServiceRequirementId, int newServiceRequirement, DateTime oldExpiry)
        {
            var expiry = new ServiceRequirementExpiry();
            {
                foreach (var result in context.opsapp_ReadExpiryReCalculationWithTurnaround(turnaroundId, oldServiceRequirementId, newServiceRequirement, oldExpiry))
                {
                    expiry.Expiry = result.Value;

                }
                return expiry;
            }
        }
    }
}
