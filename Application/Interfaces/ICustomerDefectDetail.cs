using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ICustomerDefectDetail
    /// </summary>
    public interface ICustomerDefectDetail
    {
        int TurnaroundId { get; set; }

        int CustomerDefectId { get; set; }

        DateTime CreatedDate { get; set; }

        int CreatedBy { get; set; }

        string CreatedUser { get; set; }

        int StatusId { get; set; }

        string StatusName { get; set; }

        string MissingInformation { get; set; }

        string DetailsInformation { get; set; }

        string InternalDetailsInformation { get; set; }

        string ResponseInformation { get; set; }

        string ExternalId { get; set; }
    }
}
