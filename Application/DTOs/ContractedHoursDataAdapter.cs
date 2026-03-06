using System;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ContractedHoursDataAdapter : DataAdapterBase, IContractedHoursDataAdapter
    {
        #region IContractedHoursDataAdapter Members

        /// <summary>
        /// ArchiveContractedHours operation
        /// </summary>
        public void ArchiveContractedHours(int contractedHoursIndexId, int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ReadContractedHoursByCustomer operation
        /// </summary>
        public IQueryable<IContractedHours> ReadContractedHoursByCustomer(int customerId)
        {
            try
            {
                var contractedHoursRepository = ContractedHoursRepository.New(WorkUnit);
                return contractedHoursRepository.GetContractedHoursByCustomer(customerId);
            }
            catch (Exception)
            {
                

                throw;
            }

        }

        #endregion
    }
}