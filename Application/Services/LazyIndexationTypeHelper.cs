using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyIndexationTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(IndexationType concreteIndexationType,
                                     IndexationType genericIndexationType)
        {
            concreteIndexationType.IndexationTypeId = genericIndexationType.IndexationTypeId;
            concreteIndexationType.Text = genericIndexationType.Text;
        }
    }
}