using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class LazyFastTrackRequestLineHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FastTrackRequestLine concreteFastTrackRequestLine, FastTrackRequestLine genericFastTrackRequestLine)
        {
					
			concreteFastTrackRequestLine.FastTrackRequestLineId = genericFastTrackRequestLine.FastTrackRequestLineId;			
			concreteFastTrackRequestLine.FastTrackRequestId = genericFastTrackRequestLine.FastTrackRequestId;			
			concreteFastTrackRequestLine.TurnaroundId = genericFastTrackRequestLine.TurnaroundId;			
			concreteFastTrackRequestLine.ContainerMasterDefinitionId = genericFastTrackRequestLine.ContainerMasterDefinitionId;			
			concreteFastTrackRequestLine.ContainerInstanceId = genericFastTrackRequestLine.ContainerInstanceId;
		}
	}
}
		