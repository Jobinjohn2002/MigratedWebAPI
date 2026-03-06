using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Indicates whether the sample is used for request or response
    /// </summary>
    public enum SampleDirection
    {
        Request = 0,
        Response
    }
}