using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ModernStoreAPI.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreAPIDataContext _context;

        public CustomerRepository(ModernStoreAPIDataContext context)
        {
            _context = context;
        }
        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public Customer Get(string document)
        {
            return _context.Customers.Where(x => x.Document.Number == document).FirstOrDefault();
        }

        public Customer GetByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
