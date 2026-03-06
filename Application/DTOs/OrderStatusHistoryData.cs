using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderStatusHistoryData
    /// </summary>
    public class OrderStatusHistoryData
    {
        public int OrderStatusHistoryId;
        public int OrderId;
        public int OrderStatusId;
        public int? CommentId;
        public DateTime CreatedDate;
        public int UserId;
        public UserData User;
        public OrderStatusData OrderStatus;
        public OrderData Order;
        public string CommentText;
    }
}
