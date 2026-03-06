using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IServiceParameterModel
    /// </summary>
    public interface IServiceParameterModel
    {
        long Ticks { get; set; }
        string Token { get; set; }
        string Filename { get; set; }
        byte[] Data { get; set; }
    }
}
