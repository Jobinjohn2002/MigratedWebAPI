using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class LazyFastTrackRequestStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FastTrackRequestStatus concreteFastTrackRequestStatus, FastTrackRequestStatus genericFastTrackRequestStatus)
        {
					
			concreteFastTrackRequestStatus.FastTrackRequestStatusId = genericFastTrackRequestStatus.FastTrackRequestStatusId;			
			concreteFastTrackRequestStatus.Text = genericFastTrackRequestStatus.Text;
		}
	}
}
		