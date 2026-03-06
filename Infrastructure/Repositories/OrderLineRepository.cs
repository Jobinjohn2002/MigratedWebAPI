using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class OrderLineRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public OrderLine Get(int indexId)
        {
            return Repository.Find(il => il.IndexId == indexId).FirstOrDefault();
        }

        /// <summary>
        /// Get operation
        /// </summary>
        public OrderLine Get(Guid orderLineUid)
        {
            return Repository.Find(il => il.OrderLineUid == orderLineUid).FirstOrDefault();
        }

        /// <summary>
        /// GetAllOrderLinesByOrderUid operation
        /// </summary>
        public IQueryable<OrderLine> GetAllOrderLinesByOrderUid(Guid orderUid)
        {
            return Repository.Find(il => il.OrderUid == orderUid);
        }
        /// <summary>
        /// GetAllOrderLinesByItemUid operation
        /// </summary>
        public IQueryable<OrderLine> GetAllOrderLinesByItemUid(Guid itemUid)
        {
            return Repository.Find(il => il.ItemUid == itemUid);
        }
    }
}