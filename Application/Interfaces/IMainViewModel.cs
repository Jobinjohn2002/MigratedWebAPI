using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IMainViewModel
    /// </summary>
    public interface IMainViewModel : INavigationViewModel
    {
        /// <summary>
        /// Get the command to initiate showing the find Stock UI.
        /// </summary>
        ICommand FindStock { get; }

        /// <summary>
        /// Get the command to initiate showing the Put Away Stock UI.
        /// </summary>
        ICommand PutStockAway { get; }

        /// <summary>
        /// Get the command to initiate the Pick Stock UI.
        /// </summary>
        ICommand PickStock { get; }

        /// <summary>
        /// Get the command to initiate the Stock Take UI.
        /// </summary>
        ICommand StockTake { get; }

        /// <summary>
        /// Get the command to initiate the Configuration UI.
        /// </summary>
        ICommand Configure { get; }
    }
}
