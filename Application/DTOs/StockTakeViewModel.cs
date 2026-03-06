using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StockTakeViewModel
    /// </summary>
    public class StockTakeViewModel : ViewModel, IStockTakeViewModel
    {
        private StockAction _stockAction;
        public StockAction StockAction
        {
            get { return _stockAction; }
            set
            {
                _stockAction = value;

                NotifyPropertyChanged();
            }
        }

        public StockTakeViewModel()
            : base(App.Translator.GetText("ViewModels", nameof(StockTakeViewModel), nameof(Title)))
        {
            StockAction = new StockAction
            {
                Action = StockActionType.StockTake
            };
        }
    }
}
