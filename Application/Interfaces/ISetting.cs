using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ISetting
    /// </summary>
    public interface ISetting
    {
        string Value { get; set; }
    }
}
