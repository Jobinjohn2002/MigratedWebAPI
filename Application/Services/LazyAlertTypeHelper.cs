using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyAlertTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(AlertType concreteAlertType, AlertType genericAlertType)
        {
            concreteAlertType.AlertTypeId = genericAlertType.AlertTypeId;
            concreteAlertType.Text = genericAlertType.Text;
        }
    }
}