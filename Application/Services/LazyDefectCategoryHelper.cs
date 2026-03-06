using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ref DefectCategory concreteDefectCategory, ref IDefectCategory genericDefectCategory)
        {

            concreteDefectCategory.DefectCategoryUid = genericDefectCategory.DefectCategoryUid == Guid.Empty
                                 ? EngineUtility.GenerateNewGuid()
                                 : genericDefectCategory.DefectCategoryUid;

            concreteDefectCategory.IndexId = genericDefectCategory.IndexId;
            concreteDefectCategory.Category = genericDefectCategory.Category;
        }
    }
}
