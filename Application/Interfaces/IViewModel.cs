using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IViewModel
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged
    {
        IViewModel Parent { get; set; }

        bool IsBusy { get; set; }

        string Title { get; set; }
    }
}
