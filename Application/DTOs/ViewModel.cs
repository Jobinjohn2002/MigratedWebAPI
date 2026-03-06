using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public abstract class ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// NotifyPropertyChanged operation
        /// </summary>
        public void NotifyPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;

                    NotifyPropertyChanged();
                }
            }
        }

        private IViewModel _parent;
        public IViewModel Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    _parent = value;

                    NotifyPropertyChanged();
                }
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;

                    NotifyPropertyChanged();
                }
            }
        }

        protected ViewModel(string title)
        {
            Title = title;
        }
    }
}
