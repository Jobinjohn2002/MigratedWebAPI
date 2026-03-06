using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class CategoryDataAdapter : DataAdapterBase, ICategoryDataAdapter
    {
        #region ICategoryDataAdapter Members

        /// <summary>
        /// ArchiveCategory operation
        /// </summary>
        public void ArchiveCategory(int categoryIndexId, int userId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}