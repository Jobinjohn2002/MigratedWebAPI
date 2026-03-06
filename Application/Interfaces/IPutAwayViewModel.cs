using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IPutAwayViewModel
    /// </summary>
    public interface IPutAwayViewModel : IViewModel
    {
        StockAction StockAction { get; set; }
    }
}
