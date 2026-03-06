using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FindStockViewModel
    /// </summary>
    public class FindStockViewModel : NavigationViewModel, IFindStockViewModel
    {
        public FindStockViewModel()
            : base(App.Translator.GetText("ViewModels", nameof(FindStockViewModel), nameof(Title)))
        {
        }
    }
}
