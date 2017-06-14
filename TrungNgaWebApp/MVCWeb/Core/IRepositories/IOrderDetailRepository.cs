using System.Collections.Generic;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.IRepositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        void UpdateOrderDetail(List<OrderDetail> orderDetails, int orderId);
    }
}