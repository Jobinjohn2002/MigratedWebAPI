using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public abstract class NavigationViewModel : ViewModel, INavigationViewModel
    {
        public INavigator Navigator
        {
            get;
            set;
        }

        protected NavigationViewModel(string title)
            : base(title)
        {
        }

        public void NavigateTo<TToViewModel>() 
            where TToViewModel : class, IViewModel
        {
            NavigateTo<TToViewModel>(InstanceFactory.GetInstance<TToViewModel>());
        }

        public void NavigateTo<TToViewModel>(TToViewModel viewModel)
            where TToViewModel : IViewModel
        {
            Show<TToViewModel>(viewModel, false);
        }

        public void ShowDialog<TDialogViewModel>()
            where TDialogViewModel : class, IViewModel
        {
            ShowDialog<TDialogViewModel>(InstanceFactory.GetInstance<TDialogViewModel>());
        }

        public void ShowDialog<TDialogViewModel>(TDialogViewModel viewModel)
            where TDialogViewModel : IViewModel
        {
            Show<TDialogViewModel>(viewModel, true);
        }

        private void Show<TViewModel>(TViewModel viewModel, bool dialog)
            where TViewModel : IViewModel
        {
            var navigator = InstanceFactory.GetInstance<INavigator>();

            navigator.ViewResolver = InstanceFactory.GetInstance<IViewResolver>();

            if (dialog)
            {
                navigator.ShowDialog(this, viewModel);
            }
            else
            {
                navigator.Navigate(this, viewModel);
            }
        }
    }
}
