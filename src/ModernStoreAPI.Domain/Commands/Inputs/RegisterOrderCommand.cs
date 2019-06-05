using ModernStoreAPI.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Commands.Inputs
{
    public class RegisterOrderCommand : ICommand
    {
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }
    }
}
