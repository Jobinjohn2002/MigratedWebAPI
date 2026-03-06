using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
		

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class CustomerRepository
	{
        /// <summary>
        /// Get operation
        /// </summary>
        public Customer Get(int indexId)
        {
            return Repository.Find(c => c.IndexId == indexId).FirstOrDefault();
        }
        /// <summary>
        /// Get operation
        /// </summary>
        public Customer Get(Guid uid)
        {
            return Repository.Find(c => c.CustomerUid == uid).FirstOrDefault();
        }
        /// <summary>
        /// Search operation
        /// </summary>
        public IQueryable<Customer> Search(string name)
        {
            return Repository.Find(c => c.Name.Contains(name));
        }
	}
}