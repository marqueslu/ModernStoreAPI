using ModernStoreAPI.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
