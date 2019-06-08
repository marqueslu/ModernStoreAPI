using ModernStoreAPI.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Commands.Results
{
    public class GetCustomerCommandResult : ICommandResult
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
