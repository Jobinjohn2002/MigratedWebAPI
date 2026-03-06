using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// INavigationViewModel
    /// </summary>
    public interface INavigationViewModel : IViewModel
    {
        /// <summary>
        /// Request an instance of the specified view model from the instance factory and navigate to it.
        /// </summary>
        void NavigateTo<T>() 
            where T : class, IViewModel;

        /// <summary>
        /// Navigate to the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model to navigate to.</param>
        void NavigateTo<TToViewModel>(TToViewModel viewModel)
            where TToViewModel : IViewModel;
    }
}
