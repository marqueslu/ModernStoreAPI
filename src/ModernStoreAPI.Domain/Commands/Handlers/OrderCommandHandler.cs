using Flunt.Notifications;
using ModernStoreAPI.Domain.Commands.Inputs;
using ModernStoreAPI.Domain.Commands.Results;
using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Shared.Commands;

namespace ModernStoreAPI.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;


        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public ICommandResult Handle(RegisterOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);

            var order = new Order(customer, command.DeliveryFee, command.Discount);

            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            AddNotifications(order.Notifications);

            if (Valid)
            {
                _orderRepository.Save(order);
            }

            return new RegisterOrderCommandResult
            {
                Number = order.Number
            };
        }
    }
}
