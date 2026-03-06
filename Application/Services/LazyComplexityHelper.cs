using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyComplexityHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Complexity concreteComplexity, Complexity genericComplexity)
        {
            concreteComplexity.ComplexityId = genericComplexity.ComplexityId;
            concreteComplexity.Text = genericComplexity.Text;
            concreteComplexity.LegacyFacilityOrigin = genericComplexity.LegacyFacilityOrigin;
            concreteComplexity.LegacyImported = genericComplexity.LegacyImported;
        }
    }
}