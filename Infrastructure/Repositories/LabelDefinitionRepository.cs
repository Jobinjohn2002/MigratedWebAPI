using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class LabelDefinitionRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public LabelDefinition Get(int labelDefinitionId)
        {
            return Repository.Find(labelDefinition => labelDefinition.LabelDefinitionId == labelDefinitionId).FirstOrDefault();
        }
	}
}