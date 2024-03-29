﻿using ModernStoreAPI.Domain.Commands.Results;
using ModernStoreAPI.Domain.Entities;
using System;

namespace ModernStoreAPI.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        GetCustomerCommandResult Get(string username);
        Customer GetByUsername(string username);
        //Customer Get(string document);
        Customer GetByUserId(Guid id);       
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);
    }
}
