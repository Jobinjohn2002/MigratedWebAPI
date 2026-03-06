using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class TurnaroundAssignedRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public TurnaroundAssigned Get(int turnaroundAssignedUid)
        {
            return Repository.Find(turnaroundAssigned => turnaroundAssigned.TurnaroundAssignedId == turnaroundAssignedUid).FirstOrDefault();
        }

        /// <summary>
        /// GetTurnaroundAssignedByTurnarounChildId operation
        /// </summary>
        public TurnaroundAssigned GetTurnaroundAssignedByTurnarounChildId(int turnaroundChildId) 
        {
            return Repository.Find(turnaroundAssigned => turnaroundAssigned.TurnaroundChildId == turnaroundChildId).FirstOrDefault();
        }

        /// <summary>
        /// GetParentTurnaround operation
        /// </summary>
        public IQueryable<TurnaroundAssigned> GetParentTurnaround(int turnaroundChildId)
        {
            return Repository.Find(ta => ta.TurnaroundChildId == turnaroundChildId).AsQueryable();
        }

        /// <summary>
        /// GetAssignedToParentTurnaround operation
        /// </summary>
        public IQueryable<TurnaroundAssigned> GetAssignedToParentTurnaround(int parentTurnaroundId)
        {
            return Repository.Find(ta => ta.TurnaroundParentId == parentTurnaroundId).AsQueryable();
        }
    }
} 