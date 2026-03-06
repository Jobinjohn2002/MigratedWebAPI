using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IStockTakeViewModel
    /// </summary>
    public interface IStockTakeViewModel : IViewModel
    {
        StockAction StockAction { get; set; }
    }
}
