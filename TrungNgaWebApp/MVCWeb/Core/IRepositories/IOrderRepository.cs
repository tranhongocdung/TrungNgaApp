﻿using System.Collections.Generic;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        int Create(Order order);
        bool UpdateOrder(Order order);
        void CompleteOrder(int orderId);
        Order GetWithOrderDetails(int id);
        Order GetWithCustomerAndOrderDetails(int id);
        List<Order> GetList(FilterParams fp, ref int totalCount);
    }
}