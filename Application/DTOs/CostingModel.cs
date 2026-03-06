using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class CostingModel
    {
        /// <summary>
        /// GetById operation
        /// </summary>
        public static CostingModel GetById(int costingModelId, IPathwayRepository repository = null)
        {
            Expression<Func<CostingModel, bool>> expr = cm => cm.CostingModelId == costingModelId;

            if (repository != null)
                return repository.SingleOrDefault(expr);

            using (repository = InstanceFactory.GetInstance<IPathwayRepository>())
            {
                return repository.SingleOrDefault(expr);
            }
        }

        /// <summary>
        /// GetByCustomerDefinition operation
        /// </summary>
        public static CostingModel GetByCustomerDefinition(int customerDefinitionId,
            IPathwayRepository repository = null)
        {
            Expression<Func<CostingModel, bool>> expr = cm => cm.CustomerDefinitionId == customerDefinitionId;

            if (repository != null)
                return repository.SingleOrDefault(expr);

            {
                return repository.SingleOrDefault(expr);
            }
        }

        /// <summary>
        /// DeleteById operation
        /// </summary>
        public static void DeleteById(int costingModelId, IPathwayRepository repository = null)
        {
            var dispose = repository == null;

            if (repository == null)
                repository = InstanceFactory.GetInstance<IPathwayRepository>();

            var entity = GetById(costingModelId, repository);

            repository.Delete(entity);

            if (!dispose) 
                return;
            
            repository.CommitChanges();

            repository.Dispose();
        }
    }
}
