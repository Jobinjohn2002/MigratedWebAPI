using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IUserExtendedProperty
    /// </summary>
    public interface IUserExtendedProperty
    {
        int IndexId { get; set; }
        string LegacyId { get; set; }
        string BadgeNumber { get; set; }
        Guid ExtendedPropertyUid { get; set; }
        string Sqbarcode { get; set; }
    }
}
