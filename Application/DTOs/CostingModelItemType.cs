using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class CostingModelItemType
    {
        /// <summary>
        /// GetById operation
        /// </summary>
        public static CostingModelItemType GetById(int costingModelItemTypeId, IPathwayRepository repository = null)
        {
            Expression<Func<CostingModelItemType, bool>> expr = cmit => cmit.CostingModelItemTypeId == costingModelItemTypeId;

            if (repository != null)
                return repository.SingleOrDefault(expr);

            using (repository = InstanceFactory.GetInstance<IPathwayRepository>())
            {
                return repository.SingleOrDefault(expr);
            }
        }

        /// <summary>
        /// DeleteById operation
        /// </summary>
        public static void DeleteById(int costingModelItemTypeId, IPathwayRepository repository = null)
        {
            var dispose = repository == null;

            if (repository == null)
                repository = InstanceFactory.GetInstance<IPathwayRepository>();

            var entity = GetById(costingModelItemTypeId, repository);

            repository.Delete(entity);

            if (!dispose) 
                return;
            
            repository.CommitChanges();

            repository.Dispose();
        }
    }
}
