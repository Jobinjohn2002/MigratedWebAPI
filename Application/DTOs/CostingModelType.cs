using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class CostingModelType
    {
        /// <summary>
        /// GetById operation
        /// </summary>
        public static CostingModelType GetById(int costingModelTypeId, IPathwayRepository repository = null)
        {
            Expression<Func<CostingModelType, bool>> expr = cmt => cmt.CostingModelTypeId == costingModelTypeId;

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
        public static void DeleteById(int costingModelTypeId, IPathwayRepository repository = null)
        {
            var dispose = repository == null;

            if (repository == null)
                repository = InstanceFactory.GetInstance<IPathwayRepository>();

            var entity = GetById(costingModelTypeId, repository);

            repository.Delete(entity);

            if (!dispose) 
                return;
            
            repository.CommitChanges();

            repository.Dispose();
        }
    }
}
