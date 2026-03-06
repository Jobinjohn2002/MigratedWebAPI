using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserCategory concreteUserCategory, UserCategory genericUserCategory)
        {
            concreteUserCategory.UserCategoryId = genericUserCategory.UserCategoryId;
            concreteUserCategory.Text = genericUserCategory.Text;
            concreteUserCategory.LegacyFacilityOrigin = genericUserCategory.LegacyFacilityOrigin;
            concreteUserCategory.LegacyImported = genericUserCategory.LegacyImported;
        }
    }
}