using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyIndexationCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(IndexationCategory concreteIndexationCategory,
                                     IndexationCategory genericIndexationCategory)
        {
            concreteIndexationCategory.IndexationCategoryId = genericIndexationCategory.IndexationCategoryId;
            concreteIndexationCategory.Text = genericIndexationCategory.Text;
        }
    }
}