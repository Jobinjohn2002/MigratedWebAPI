using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemExceptionHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemException concreteItemException, ItemException genericItemException)
		{

			concreteItemException.ItemExceptionId = genericItemException.ItemExceptionId;
			concreteItemException.ArchivedUserId = genericItemException.ArchivedUserId;
			concreteItemException.CreatedUserId = genericItemException.CreatedUserId;
			concreteItemException.ItemExceptionReasonId = genericItemException.ItemExceptionReasonId;
			concreteItemException.ItemInstanceId = genericItemException.ItemInstanceId;
			concreteItemException.Created = genericItemException.Created;
			concreteItemException.Archived = genericItemException.Archived;
			concreteItemException.ContainerContentId = genericItemException.ContainerContentId;
		}
	}
}
		