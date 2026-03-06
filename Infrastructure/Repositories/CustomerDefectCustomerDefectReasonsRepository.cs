using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// CustomerDefectCustomerDefectReasonsRepository
    /// </summary>
    public class CustomerDefectCustomerDefectReasonsRepository
    {
        /// <summary>
        /// Add operation
        /// </summary>
        public void Add(int customerDefectId, byte customerDefectReasonId)
        {
            using (var context = new OperativeModelContainer())
            {
                var cd = new CustomerDefect();
                cd.CustomerDefectId = customerDefectId;

                var cdr = new CustomerDefectReason();
                cdr.CustomerDefectReasonId = customerDefectReasonId;

                context.CustomerDefect.Attach(cd);
                context.CustomerDefectReason.Attach(cdr);

                cd.CustomerDefectReasons.Add(cdr);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete operation
        /// </summary>
        public void Delete(int customerDefectId, byte customerDefectReasonId)
        {
            {
                var cd = new CustomerDefect();
                cd.CustomerDefectId = customerDefectId;

                var cdr = new CustomerDefectReason();
                cdr.CustomerDefectReasonId = customerDefectReasonId;

                context.CustomerDefect.Attach(cd);
                context.CustomerDefectReason.Attach(cdr);

                cd.CustomerDefectReasons.Remove(cdr);

                context.SaveChanges();
            }
        }
    }
}
