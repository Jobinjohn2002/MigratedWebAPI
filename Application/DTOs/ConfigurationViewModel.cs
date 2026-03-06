using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfigurationViewModel
    /// </summary>
    public class ConfigurationViewModel : NavigationViewModel, IConfigurationViewModel
    {
        public ConfigurationViewModel()
            : base(App.Translator.GetText("ViewModels", nameof(ConfigurationViewModel), nameof(Title)))
        {
        }
    }
}
