using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModernStoreAPI.Domain.Commands.Results;
using System.Data.SqlClient;
using Dapper;

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

        public GetCustomerCommandResult Get(string username)
        {
            //return _context.Customers.Include(x => x.User).AsNoTracking().Select(x => new GetCustomerCommandResult
            //{
            //    Name = x.Name.ToString(),
            //    Document = x.Document.Number,
            //    Email = x.Email.Address,
            //    Username = x.User.Username,
            //    Password = x.User.Password,
            //    Active = x.User.Active
            //}).FirstOrDefault(x => x.Username == username);
            var query = "SELECT c.FirstName + ' ' + c.LastName as Name, c.Document, c.Email, u.Username, u.Username, u.Active from Customer as c inner join [User] as u on c.userid = u.id where u.Username = @Username and u.Active = 1";
            using (var con = new SqlConnection(@""))
            {
                con.Open();
                return con.Query<GetCustomerCommandResult>(query, new { Username = username }).FirstOrDefault();
            }
        }

        //public Customer Get(string document)
        //{
        //    return _context.Customers.Where(x => x.Document.Number == document).FirstOrDefault();
        //}

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
