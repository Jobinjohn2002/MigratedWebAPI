using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class IQueryableContainerMasterExtensions
    {
        #region Item Type Queries

        /// <summary>
        /// OfItemType operation
        /// </summary>
        public static IQueryable<ContainerMaster> OfItemType(this IQueryable<ContainerMaster> qry, IEnumerable<KnownItemType> itemTypes)
        {
            return OfItemType(qry, itemTypes.Cast<short>());
        }

        /// <summary>
        /// OfItemType operation
        /// </summary>
        public static IQueryable<ContainerMaster> OfItemType(this IQueryable<ContainerMaster> qry, IEnumerable<short> itemTypes)
        {
            if (qry == null)
                throw new ArgumentNullException("qry");

            return qry.Where(cm => itemTypes.Contains(cm.ItemTypeId));
        }

        /// <summary>
        /// OfBaseItemType operation
        /// </summary>
        public static IQueryable<ContainerMaster> OfBaseItemType(this IQueryable<ContainerMaster> qry, IEnumerable<KnownBaseItemType> baseItemTypes)
        {
            return OfBaseItemType(qry, baseItemTypes.Cast<short>());
        }

        /// <summary>
        /// OfBaseItemType operation
        /// </summary>
        public static IQueryable<ContainerMaster> OfBaseItemType(this IQueryable<ContainerMaster> qry, IEnumerable<short> baseItemTypes)
        {
            if (qry == null)
                throw new ArgumentNullException("qry");

            var types = baseItemTypes.Cast<short?>();

            return qry.Where(cm => types.Contains(cm.ItemType.ParentItemTypeId));
        }

        #endregion
    }
}
