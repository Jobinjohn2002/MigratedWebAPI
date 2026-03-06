using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazySpecialityHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Speciality concreteSpeciality, Speciality genericSpeciality)
        {
            concreteSpeciality.SpecialityId = genericSpeciality.SpecialityId;
            concreteSpeciality.Text = genericSpeciality.Text;
            concreteSpeciality.LegacyFacilityOrigin = genericSpeciality.LegacyFacilityOrigin;
            concreteSpeciality.LegacyImported = genericSpeciality.LegacyImported;
        }
    }
}