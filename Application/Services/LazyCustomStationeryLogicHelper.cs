using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCustomStationeryLogicHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CustomStationeryLogic concreteCustomStationeryLogic, CustomStationeryLogic genericCustomStationeryLogic)
        {
					
			concreteCustomStationeryLogic.CustomStationeryLogicId = genericCustomStationeryLogic.CustomStationeryLogicId;			
			concreteCustomStationeryLogic.CustomStationeryLogicId = genericCustomStationeryLogic.CustomStationeryLogicId;			
			concreteCustomStationeryLogic.CustomerDefinitionId = genericCustomStationeryLogic.CustomerDefinitionId;			
			concreteCustomStationeryLogic.FacilityId = genericCustomStationeryLogic.FacilityId;			
			concreteCustomStationeryLogic.TenancyId = genericCustomStationeryLogic.TenancyId;
		}
	}
}
		