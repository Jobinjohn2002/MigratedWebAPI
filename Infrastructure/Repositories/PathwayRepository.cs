using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// PathwayRepository
    /// </summary>
    public class PathwayRepository
    {
        private OperativeModelContainer _container;
        private IDataManager _dataManager;

        public PathwayRepository()
        {
            _container = new OperativeModelContainer();
            _dataManager = new DataManager(_container);
        }

        public OperativeModelContainer Container
        {
            get { return _container; }
        }

        public IDataManager DataManager
        {
            get { return _dataManager; }
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {
            if (_container != null)
                _container.Dispose();

            if (_dataManager != null)
                _dataManager.Dispose();
        }
    }
}
