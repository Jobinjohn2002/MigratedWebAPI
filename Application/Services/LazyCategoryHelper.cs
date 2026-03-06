using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Category concreteCategory, Category genericCategory)
        {
            concreteCategory.CategoryId = genericCategory.CategoryId;
            concreteCategory.ParentCategoryId = genericCategory.ParentCategoryId;
            concreteCategory.Text = genericCategory.Text;
            concreteCategory.LegacyId = genericCategory.LegacyId;
            concreteCategory.LegacyFacilityOrigin = genericCategory.LegacyFacilityOrigin;
            concreteCategory.LegacyImported = genericCategory.LegacyImported;
        }
    }
}