using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ServiceBase
    /// </summary>
    public class ServiceBase
    {
        private ICacheManager _cacheManager;
        private ITranslator _translator;

        public ICacheManager CacheManager
        {
            get
            {
                if (_cacheManager == null)
                    _cacheManager = InstanceFactory.GetInstance<ICacheManager>();

                return _cacheManager;
            }
        }

        public ITranslator Translator
        {
            get
            {
                if (_translator == null)
                    _translator = InstanceFactory.GetInstance<ITranslator>();

                return _translator;
            }
        }

        public DebugInfo Debug
        {
            get;
            set;
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
