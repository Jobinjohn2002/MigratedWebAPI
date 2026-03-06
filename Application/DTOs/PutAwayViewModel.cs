using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PutAwayViewModel
    /// </summary>
    public class PutAwayViewModel : ViewModel, IPutAwayViewModel
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

        public PutAwayViewModel()
            : base(App.Translator.GetText("ViewModels", nameof(PutAwayViewModel), nameof(Title)))
        {
            StockAction = new StockAction
            {
                Action = StockActionType.PutAway
            };
        }
    }
}
