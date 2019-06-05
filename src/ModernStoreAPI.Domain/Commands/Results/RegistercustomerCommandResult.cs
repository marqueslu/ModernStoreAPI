using ModernStoreAPI.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Commands.Results
{
    public class RegistercustomerCommandResult : ICommandResult
    {
        public RegistercustomerCommandResult()
        {
        }

        public RegistercustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
