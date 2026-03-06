using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyAlertHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Alert concreteAlert, Alert genericAlert)
        {
            concreteAlert.AlertId = genericAlert.AlertId;
            concreteAlert.UserId = genericAlert.UserId;
            concreteAlert.FacilityId = genericAlert.FacilityId;
            concreteAlert.AlertTypeId = genericAlert.AlertTypeId;
            concreteAlert.Created = genericAlert.Created;
            concreteAlert.Text = genericAlert.Text;
        }
    }
}