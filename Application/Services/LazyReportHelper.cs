using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyReportHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Report concreteReport, Report genericReport)
        {
            concreteReport.ReportId = genericReport.ReportId;
            concreteReport.ReportCategoryId = genericReport.ReportCategoryId;
            concreteReport.Text = genericReport.Text;
            concreteReport.Description = genericReport.Description;
            concreteReport.URL = genericReport.URL;
            concreteReport.IsLive = genericReport.IsLive;
            concreteReport.LegacyFacilityOrigin = genericReport.LegacyFacilityOrigin;
            concreteReport.LegacyImported = genericReport.LegacyImported;
        }
    }
}