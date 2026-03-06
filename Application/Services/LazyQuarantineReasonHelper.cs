using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyQuarantineReasonHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(QuarantineReason concreteQuarantineReason, QuarantineReason genericQuarantineReason)
        {
            concreteQuarantineReason.QuarantineReasonId = genericQuarantineReason.QuarantineReasonId;
            concreteQuarantineReason.Text = genericQuarantineReason.Text;
            concreteQuarantineReason.IsUserSelectable = genericQuarantineReason.IsUserSelectable;
        }
    }
}
