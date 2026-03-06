using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class PrinterRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public Printer Get(int printerId)
        {
            return Repository.Find(p => p.PrinterId == printerId).FirstOrDefault();
        }

        /// <summary>
        /// GetByFacility operation
        /// </summary>
        public IQueryable<Printer> GetByFacility(short facilityId)
        {
            return Repository.Find(p => p.FacilityId == facilityId && p.Archived == null);
        }
    }
}