using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum NotificationTypeIdentifier
    {
        Information = 1,
        Success = 2,
        Warning = 3,
        Error = 4,
        Printer = 5,
    }
}
