using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class CycleParameterData 
	{
        public CycleParameterData ()
        {

        }
        public List<CycleParameterDetailData> CycleParameterDetails;
        public List<CycleParameterAirRemovalData> AirRemovalDetails;

	}
}
		