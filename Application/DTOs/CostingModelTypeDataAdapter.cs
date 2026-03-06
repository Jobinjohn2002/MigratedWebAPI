using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class CostingModelTypeDataAdapter : DataAdapterBase, ICostingModelTypeDataAdapter
    {
        #region ICostingModelTypeDataAdapter Members

        /// <summary>
        /// ArchiveCostingModelType operation
        /// </summary>
        public void ArchiveCostingModelType(byte costingModelTypecostingModelTypeId, int userId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}