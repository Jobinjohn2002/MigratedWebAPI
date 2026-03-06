using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyReportCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ReportCategory concreteReportCategory,
                                     ReportCategory genericReportCategory)
        {
            concreteReportCategory.ReportCategoryId = genericReportCategory.ReportCategoryId;
            concreteReportCategory.ParentId = genericReportCategory.ParentId;
            concreteReportCategory.Text = genericReportCategory.Text;
            concreteReportCategory.IsLive = genericReportCategory.IsLive;
            concreteReportCategory.LegacyFacilityOrigin = genericReportCategory.LegacyFacilityOrigin;
            concreteReportCategory.LegacyImported = genericReportCategory.LegacyImported;
        }
    }
}