using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// CustomerDefectCustomerDefectReasonDataAdapter
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// CustomerDefectCustomerDefectReasonDataAdapter
    /// </summary>
    public class CustomerDefectCustomerDefectReasonDataAdapter : DataAdapterBase,
                                                                 ICustomerDefectCustomerDefectReasonDataAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAdapterBase"/> class.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        /// <remarks></remarks>
        internal CustomerDefectCustomerDefectReasonDataAdapter(IUnitOfWork efUnitOfWork)
            : base(efUnitOfWork)
        {
        }

        #region ICustomerDefectCustomerDefectReasonDataAdapter Members

        /// <summary>
        /// Updates the specified customer defect id.
        /// </summary>
        /// <param name="customerDefectId">The customer defect id.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Update operation
        /// </summary>
        public bool Update(int customerDefectId, IList<byte> types)
        {
            var customerDefectRepository = CustomerDefectRepository.New(WorkUnit);
            var customerDefectCustomerDefectReasonsRepository = new CustomerDefectCustomerDefectReasonsRepository();
            IQueryable<ICustomerDefectReason> customerDefectReasons =
                customerDefectRepository.ReadCustomerDefectsReasonsByCustomerDefectId(customerDefectId);

            using (var transaction = new TransactionScope())
            {
                foreach (var reason in customerDefectReasons)
                {
                    customerDefectCustomerDefectReasonsRepository.Delete(customerDefectId, reason.CustomerDefectReasonId);
                }

                foreach (byte newTypeId in types)
                {
                    customerDefectCustomerDefectReasonsRepository.Add(customerDefectId, newTypeId);
                }

                transaction.Complete();
                return true;
            }
        }

        #endregion
    }
}