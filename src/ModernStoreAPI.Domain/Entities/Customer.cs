using Flunt.Validations;
using ModernStoreAPI.Domain.ValueObjects;
using ModernStoreAPI.Shared.Entities;
using System;

namespace ModernStoreAPI.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Document document, Email email, User user)
        {
            Name = name;
            BirthDate = null;
            Document = document;
            Email = email;
            User = user;
        }

        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Document Document { get; set; }
        public Email Email { get; private set; }
        public User User { get; private set; }

        public void Update(Name name, DateTime birthDate)
        {
            AddNotifications(name.Notifications);

            Name = name;
            BirthDate = birthDate;
        }
    }
}
