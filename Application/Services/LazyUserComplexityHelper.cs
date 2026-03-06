using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserComplexityHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserComplexity concreteUserComplexity,
                                     UserComplexity genericUserComplexity)
        {
            concreteUserComplexity.UserComplexitySpeciailityId = genericUserComplexity.UserComplexitySpeciailityId;
            concreteUserComplexity.UserId = genericUserComplexity.UserId;
            concreteUserComplexity.SpecialityId = genericUserComplexity.SpecialityId;
            concreteUserComplexity.ComplexityId = genericUserComplexity.ComplexityId;
            concreteUserComplexity.LegacyFacilityOrigin = genericUserComplexity.LegacyFacilityOrigin;
            concreteUserComplexity.LegacyImported = genericUserComplexity.LegacyImported;
        }
    }
}