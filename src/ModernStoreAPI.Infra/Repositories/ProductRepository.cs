using Dapper;
using ModernStoreAPI.Domain.Commands.Results;
using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
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

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var query = "SELECT [ID], [TITLE], [IMAGE], [PRICE] FROM Product";
            using (var con = new SqlConnection(@""))
            {
                con.Open();
                return con.Query<GetProductListCommandResult>(query);
            }
        }
    }
}

