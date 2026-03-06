using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class PrintHistoryRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public PrintHistory Get(int printHistoryId)
        {
            return Repository.Find(printHistory => printHistory.PrintHistoryId == printHistoryId).FirstOrDefault();
        }

        /// <summary>
        /// GetAllById operation
        /// </summary>
        public IQueryable<PrintHistory> GetAllById(int printHistoryId)
        {
            return Repository.Find(x => x.PrintHistoryId == printHistoryId);
        }

        /// <summary>
        /// GetByTurnaroundId operation
        /// </summary>
        public IQueryable<PrintHistory> GetByTurnaroundId(int turnaroundId)
        {
            return Repository.Find(x => x.PrintHistoryTurnaround.Any(y => y.TurnaroundId == turnaroundId));
        }
    }
}