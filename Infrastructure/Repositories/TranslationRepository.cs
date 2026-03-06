using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TranslationRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public Translation Get(int translationId)
        {
            return Repository.Find(translation => translation.TranslationId == translationId).FirstOrDefault();
        }

	}
}