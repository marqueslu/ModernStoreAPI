using Flunt.Validations;
using ModernStoreAPI.Domain.ValueObjects;
using ModernStoreAPI.Shared.Entities;
using System;

namespace ModernStoreAPI.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Email email, User user)
        {
            Name = name;
            BirthDate = null;
            Email = email;
            User = user;
        }

        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Email Email { get; private set; }
        public User User { get; private set; }
    }
}
