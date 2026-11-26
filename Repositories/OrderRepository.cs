using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly StoreDBContext _context;

        public OrderRepository(StoreDBContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
