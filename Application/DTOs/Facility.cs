using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class Facility 
	{
        public int? ExpiryDays { get; set; }

        /// <summary>
        /// Gets or sets IsPrintersCountZero
        /// </summary>
        public bool IsPrintersCountZero { get; set; }

        /// <summary>
        /// Gets or sets IsNotesCountZero
        /// </summary>
        public bool IsNotesCountZero { get; set; }

        public Enums.General.ItemMasterDefinitionTypeIdentifier GetItemMasterType()
        {
            switch ((Enums.FacilityType)this.FacilityTypeId)
            {
                case Enums.FacilityType.SPD:
                    return Enums.General.ItemMasterDefinitionTypeIdentifier.Reprocessing;
                case Enums.FacilityType.VendorCatalogue:
                    return Enums.General.ItemMasterDefinitionTypeIdentifier.Blueprint;
                default:
                    throw new NotImplementedException($"Type does not exist {FacilityTypeId}");

            }
        }

        public Enums.General.ContainerMasterDefinitionTypeIdentifier GetContainerMasterType()
        {
            switch ((Enums.FacilityType)this.FacilityTypeId)
            {
                case Enums.FacilityType.SPD:
                    return Enums.General.ContainerMasterDefinitionTypeIdentifier.Reprocessing;
                case Enums.FacilityType.VendorCatalogue:
                    return Enums.General.ContainerMasterDefinitionTypeIdentifier.Blueprint;
                default:
                    throw new NotImplementedException($"Type does not exist {FacilityTypeId}");

            }
        }
    }
}
		