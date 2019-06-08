using ModernStoreAPI.Domain.Entities;
using System;

namespace ModernStoreAPI.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer Get(string document);
        Customer GetByUserId(Guid id);       
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);


    }
}
