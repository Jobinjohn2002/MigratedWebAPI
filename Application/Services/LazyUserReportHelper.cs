using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserReportHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserReport concreteUserReport, UserReport genericUserReport)
        {
            concreteUserReport.UserReportId = genericUserReport.UserReportId;
            concreteUserReport.ReportId = genericUserReport.ReportId;
            concreteUserReport.UserId = genericUserReport.UserId;
            concreteUserReport.LegacyFacilityOrigin = genericUserReport.LegacyFacilityOrigin;
            concreteUserReport.LegacyImported = genericUserReport.LegacyImported;
        }
    }
}