using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class CategoryRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public Category Get(int categoryId)
        {
            return Repository.Find(category => category.CategoryId == categoryId).FirstOrDefault();
        }
	}
}