using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ModernStoreAPIDataContext _context;

        public OrderRepository(ModernStoreAPIDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
