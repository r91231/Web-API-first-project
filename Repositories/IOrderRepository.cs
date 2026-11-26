using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;
namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
    }
}
