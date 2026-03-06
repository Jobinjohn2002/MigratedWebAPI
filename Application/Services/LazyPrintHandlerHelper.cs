using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Handler retriever
    /// </summary>
    /// <summary>
    /// LazyPrintHandlerHelper
    /// </summary>
    public class LazyPrintHandlerHelper
    {
        private static readonly Lazy<LazyPrintHandlerHelper> Lazy =
            new Lazy<LazyPrintHandlerHelper>(() => new LazyPrintHandlerHelper());

        private readonly IUnityContainer _container;
        private readonly UnityConfigurationSection _unitySection;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        private LazyPrintHandlerHelper()
        {
            _container = new UnityContainer();
            _unitySection
                = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            _unitySection.Configure(_container, "PrintHandlers");
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static LazyPrintHandlerHelper Instance => Lazy.Value;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        /// <summary>
        /// GetPrintHandler operation
        /// </summary>
        public IPrintHandler GetPrintHandler(string printType)
        {
            var printHandler = _container.Resolve<IPrintHandler>(printType);
            return printHandler;
        }
    }
}