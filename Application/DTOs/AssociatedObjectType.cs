using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum AssociatedObjectType
    {
        [Description("None")]
        None = 0,

        [Description("Container")]
        ContainerMaster = 1,

        [Description("Item")]
        ItemMaster = 2,

        [Description("Container Instance")]
        ContainerInstance = 3,

        [Description("Item Instance")]
        ItemInstance = 4,

        [Description("Defect")]
        Defect = 5,

        [Description("Batch")]
        Batch = 6,

        [Description("Maintenance")]
        Maintenance = 7,

        [Description("Loan Kit")]
        LoanSet = 8,

        [Description("Customer Defect")]
        CustomerDefect = 9,

        [Description("Turnaround")]
        Turnaround = 10,

        [Description("Change Control Notification")]
        ChangeControlNote = 11
    }
}
