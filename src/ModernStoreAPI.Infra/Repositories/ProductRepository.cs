using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreAPIDataContext _context;

        public ProductRepository(ModernStoreAPIDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products.Find(id);
        }
    }
}
