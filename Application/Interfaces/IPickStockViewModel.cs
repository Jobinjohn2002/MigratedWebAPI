using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IPickStockViewModel
    /// </summary>
    public interface IPickStockViewModel : IViewModel
    {
        string Reference { get; set; }
        ObservableCollection<int> Turnarounds { get; set; }
        void AddTurnaround(int turnaroundId);
        void RemoveTurnaround(int turnaround);
    }
}
