using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum ProcessRequestType
    {
        Enquiry,
        Inbound,
        Wash,
        LogIn,
        LogOut,
    }
}
