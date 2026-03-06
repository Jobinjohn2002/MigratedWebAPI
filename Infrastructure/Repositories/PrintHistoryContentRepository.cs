using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class PrintHistoryContentRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public PrintHistoryContent Get(int printHistoryContentId)
        {
            return Repository.Find(printHistoryContent => printHistoryContent.PrintHistoryContentId == printHistoryContentId).FirstOrDefault();
        }

        /// <summary>
        /// GetByPrintHistoryId operation
        /// </summary>
        public IQueryable<PrintHistoryContent> GetByPrintHistoryId(int printHistoryId)
        {
            return Repository.Find(printHistoryContent => printHistoryContent.PrintHistoryId == printHistoryId);
        }

    }
}

