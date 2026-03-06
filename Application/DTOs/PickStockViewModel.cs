using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PickStockViewModel
    /// </summary>
    public class PickStockViewModel : NavigationViewModel, IPickStockViewModel
    {
        private string _reference;
        public string Reference
        {
            get { return _reference; }
            set
            {
                if (_reference == value)
                {
                    return;
                }

                _reference = value;

                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<int> _turnarounds;
        public ObservableCollection<int> Turnarounds
        {
            get { return _turnarounds; }
            set
            {
                _turnarounds = value;

                NotifyPropertyChanged();
            }
        }

        public PickStockViewModel()
            : base(App.Translator.GetText("ViewModels", nameof(PickStockViewModel), nameof(Title)))
        {
            Turnarounds = new ObservableCollection<int>();

            Submit = new Command(DoSubmit, () => CanSubmit);
        }

        /// <summary>
        /// AddTurnaround operation
        /// </summary>
        public void AddTurnaround(int turnaround)
        {
            if (Turnarounds.Contains(turnaround))
                return;

            Turnarounds.Insert(0, turnaround);

            Submit.ChangeCanExecute();
        }

        /// <summary>
        /// RemoveTurnaround operation
        /// </summary>
        public void RemoveTurnaround(int turnaround)
        {
            if (Turnarounds.Contains(turnaround))
            {
                Turnarounds.Remove(turnaround);
            }

            Submit.ChangeCanExecute();
        }

        /// <summary>
        /// Gets or sets Submit
        /// </summary>
        public Command Submit { get; }

        public bool CanSubmit => _turnarounds.Count > 0 && !IsBusy;

        /// <summary>
        /// DoSubmit operation
        /// </summary>
        public async void DoSubmit()
        {
            IsBusy = true;

            Submit.ChangeCanExecute();

            await Task.Delay(5000);

            IsBusy = false;

            Submit.ChangeCanExecute();
        }
    }
}
