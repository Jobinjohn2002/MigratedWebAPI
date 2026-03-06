using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Handles requesting instances, abstracts away the DI implementation and gives a single entry point to request instances.
    /// </summary>
    public static class InstanceFactory
    {
        /// <summary>
        /// Sets the DI instance resolver to be used by the application.
        /// </summary>
        public static IInstanceResolver Resolver { private get; set; }
        
        /// <summary>
        /// Gets an instance of the specified interface from the instance resolver (shortcut to Resolver.GetIntance).
        /// </summary>
        /// <typeparam name="TInterface">The interface to obtain an instance for.</typeparam>
        /// <returns>An instance of the interface.</returns>
        public static TInterface GetInstance<TInterface>() where TInterface : class
        {
            if (Resolver == null)
            {
                throw new NullReferenceException("Resolve Instance must be set before calling first GetInstance");
            }

            return Resolver.GetInstance<TInterface>();
        }
    }
}
