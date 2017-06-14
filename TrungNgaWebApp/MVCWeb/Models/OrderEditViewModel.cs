﻿using MVCWeb.AppDataLayer.Entities;

namespace MVCWeb.Models
{
    public class OrderEditViewModel
    {
        //Customer
        public Customer Customer { get; set; }
        //Order
        public Order Order { get; set; }
        public string OrderDetailJson { get; set; }

        public bool IsCompletedOrder
        {
            get { return Order != null && Order.OrderStatusId == OrderStatus.Completed; }
        }
    }
}