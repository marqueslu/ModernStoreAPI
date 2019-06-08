using Flunt.Validations;
using ModernStoreAPI.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }
        public User(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = EncryptPassword(password);
            Active = true;
            
            new Contract()
                .AreEquals(EncryptPassword(password), EncryptPassword(confirmPassword), "Password", "The password is diferent");
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331fds-fad0-4df0-bfd3-6e32239c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
