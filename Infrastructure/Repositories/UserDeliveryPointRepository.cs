using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class UserDeliveryPointRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public UserDeliveryPoint Get(int indexId)
        {
            return Repository.Find(userDeliveryPoint => userDeliveryPoint.UserDeliveryPointId == indexId).FirstOrDefault();
        }

		/// <summary>
		/// ReadDeliveryPointsByUser operation
		/// </summary>
		public IQueryable<IDeliveryPoint> ReadDeliveryPointsByUser(int userId)
		{
			return Repository.Find(utdp => utdp.UserId == userId).Select(utdp => utdp.DeliveryPoint).Where(dp => dp.Archived == null);
		}

        /// <summary>
        /// ReadDeliveryPointsByUserId operation
        /// </summary>
        public IList<BasicDeliveryPointData> ReadDeliveryPointsByUserId(int userId)
        {
            List<BasicDeliveryPointData> deliveryPoints = new List<BasicDeliveryPointData>();
            var list = Repository.Find(utdp => utdp.UserId == userId).Select(utdp => utdp.DeliveryPoint).Where(dp => dp.Archived == null);
            foreach (var item in list)
            {
                deliveryPoints.Add(new BasicDeliveryPointData(item.DeliveryPointId, item.Text));
            }
            return deliveryPoints;
        }

        /// <summary>
        /// HasDeliveryPointAccess operation
        /// </summary>
        public bool HasDeliveryPointAccess(int userId, int deliveryPointId)
        {
            return Repository.Find(udp => udp.UserId == userId && udp.DeliveryPointId == deliveryPointId && udp.DeliveryPoint.Archived == null).ToList().Count > 0;
        }

        /// <summary>
        /// DeleteByDeliveryPoint operation
        /// </summary>
        public void DeleteByDeliveryPoint(int deliveryPointId)
        {
            foreach (var deliverypoint in Repository.Find(udp => udp.DeliveryPointId == deliveryPointId))
            {
                Repository.Delete(deliverypoint);
            }     
        }
    }
}