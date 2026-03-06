using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum WashInstanceType
    {
        Tray = 1,
        Instrument = 2,

    }

    public enum WashMachineType
    {
        Machine = 1,
        Manual = 2
    }
}