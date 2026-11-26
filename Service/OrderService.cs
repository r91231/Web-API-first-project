using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
namespace Services
{
    public class OrderService:IOrderService
    {
        IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await _orderRepository.AddOrder(order);
        }
    }
}
