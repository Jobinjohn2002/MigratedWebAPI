using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class LoanSetContentsRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public LoanSetContents Get(int loanSetContentsId)
        {
            return Repository.Find(loanSetContents => loanSetContents.LoanSetContentId == loanSetContentsId).FirstOrDefault();
        }

        /// <summary>
        /// GetAllContents operation
        /// </summary>
        public IQueryable<LoanSetContents> GetAllContents(int loanSetContentsId)
        {
            return Repository.Find(loanSetContents => loanSetContents.LoanSetContentId == loanSetContentsId);
        }

        /// <summary>
        /// GetContentsByInstanceId operation
        /// </summary>
        public LoanSetContents GetContentsByInstanceId(int containerInstanceId)
        {
            return Repository.Find(loanSetContents => loanSetContents.InstanceId == containerInstanceId).FirstOrDefault();
        }

    }
}