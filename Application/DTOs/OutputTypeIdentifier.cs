using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum OutputTypeIdentifier
    {
        Traylist = 1,
        DeliveryNote = 2,
        QALabel = 3,
        Generic = 4,
        GenericLabel = 8
    }
}
