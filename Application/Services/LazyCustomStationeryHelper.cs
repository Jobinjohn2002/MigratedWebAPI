using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCustomStationeryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CustomStationery concreteCustomStationery, CustomStationery genericCustomStationery)
        {
			concreteCustomStationery.CustomStationeryId = genericCustomStationery.CustomStationeryId;			
			concreteCustomStationery.ReportPath = genericCustomStationery.ReportPath;
            concreteCustomStationery.CustomStationeryTypeId = genericCustomStationery.CustomStationeryTypeId;			
			concreteCustomStationery.LblTemplateId = genericCustomStationery.LblTemplateId;			
			concreteCustomStationery.LblDataId = genericCustomStationery.LblDataId;
		}
	}
}