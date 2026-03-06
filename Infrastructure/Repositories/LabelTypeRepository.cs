using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class LabelTypeRepository
	{
        /// <summary>
        /// Get operation
        /// </summary>
        public LabelType Get(byte labelTypeId)
        {
            return Repository.Find(labelType => labelType.LabelTypeId == labelTypeId).FirstOrDefault();
        }
	}
}