using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum LocationTypeIdentifier
    {
        [EnumMember]
        [Description("Stock")]
        Stock = 1,

        [EnumMember]
        [Description("General")]
        General = 2,

        [EnumMember]
        [Description("EndoscopeDryingCabinet")]
        EndoscopeDryingCabinet = 3,

        [EnumMember]
        [Description("EndoscopeDryingCabinetShelf")]
        EndoscopeDryingCabinetShelf = 4,

        [EnumMember]
        [Description("EndoscopeDryingCabinetDrawer")]
        EndoscopeDryingCabinetDrawer = 5,

        [EnumMember]
        [Description("AerShelf")]
        AerShelf = 110,

        [EnumMember]
        [Description("EndoscopeGeneralLocation")]
        EndoscopeGeneralLocation = 111,

        [EnumMember]
        [Description("EndoscopeStockLocation")]
        EndoscopeStockLocation = 112,

        [EnumMember]
        [Description("Aer")]
        Aer = 113
    }
}
