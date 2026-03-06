using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyScheduleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Schedule concreteSchedule, Schedule genericSchedule)
        {
					
			concreteSchedule.ScheduleId = genericSchedule.ScheduleId;			
			concreteSchedule.Text = genericSchedule.Text;			
			concreteSchedule.RepeatType = genericSchedule.RepeatType;			
			concreteSchedule.RepeatEvery = genericSchedule.RepeatEvery;			
			concreteSchedule.RepeatOn = genericSchedule.RepeatOn;			
			concreteSchedule.RepeatSkip = genericSchedule.RepeatSkip;			
			concreteSchedule.StartDate = genericSchedule.StartDate;			
			concreteSchedule.EndDate = genericSchedule.EndDate;			
			concreteSchedule.Day = genericSchedule.Day;
            concreteSchedule.CustomerDefinitionId = genericSchedule.CustomerDefinitionId;			
			concreteSchedule.CustomerGroupId = genericSchedule.CustomerGroupId;			
			concreteSchedule.Uses = genericSchedule.Uses;			
			concreteSchedule.Created = genericSchedule.Created;			
			concreteSchedule.CreatedUserId = genericSchedule.CreatedUserId;
		}
	}
}
		