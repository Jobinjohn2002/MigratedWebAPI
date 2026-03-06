using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MainViewModel
    /// </summary>
    public class MainViewModel : NavigationViewModel, IMainViewModel
    {
        /// <summary>
        /// Gets or sets FindStock
        /// </summary>
        public ICommand FindStock { get; }
        /// <summary>
        /// Gets or sets PickStock
        /// </summary>
        public ICommand PickStock { get; }
        /// <summary>
        /// Gets or sets PutStockAway
        /// </summary>
        public ICommand PutStockAway { get; }
        /// <summary>
        /// Gets or sets StockTake
        /// </summary>
        public ICommand StockTake { get; }

        /// <summary>
        /// Gets or sets Configure
        /// </summary>
        public ICommand Configure { get; }

        public MainViewModel()
            : base(App.Translator.GetText("ViewModels", nameof(MainViewModel), nameof(Title)))
        {
            FindStock = new Command(NavigateTo<IFindStockViewModel>);
            PickStock = new Command(NavigateTo<IPickStockViewModel>);
            PutStockAway = new Command(NavigateTo<IPutAwayViewModel>);
            StockTake = new Command(NavigateTo<IStockTakeViewModel>);
            Configure = new Command(ShowDialog<IConfigurationViewModel>);
        }
    }
}
