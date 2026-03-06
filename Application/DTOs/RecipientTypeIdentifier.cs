using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum RecipientTypeIdentifier
    {
        User = 1,
        Facility = 2,
        Customer = 3,
        DeliveryPoint = 4
    }
}
