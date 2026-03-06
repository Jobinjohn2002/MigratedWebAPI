using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum NotificationRuleOutcomeIdentifier
    {
        Notify = 1,
        DenyNotify = 2,
        BatchAlreadyNotifiedDeny = 3
    }
}
