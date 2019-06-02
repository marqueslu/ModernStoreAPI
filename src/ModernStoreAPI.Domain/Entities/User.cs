using ModernStoreAPI.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Active = true;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;
    }
}
