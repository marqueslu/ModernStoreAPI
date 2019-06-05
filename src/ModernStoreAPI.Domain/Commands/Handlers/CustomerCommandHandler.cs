using Flunt.Notifications;
using ModernStoreAPI.Domain.Commands.Inputs;
using ModernStoreAPI.Domain.Commands.Results;
using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Domain.Resources;
using ModernStoreAPI.Domain.Services;
using ModernStoreAPI.Domain.ValueObjects;
using ModernStoreAPI.Shared.Commands;

namespace ModernStoreAPI.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,  ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }
        //public ICommandResult Handle(UpdateCustomerCommand command)
        //{
        //    var customer = _customerRepository.Get(command.Id);

        //    if (customer == null)
        //    {
        //        AddNotification("Customer", "Customer not found.");
        //        return null;
        //    }

        //    var name = new Name(customer.Name.FirstName, customer.Name.LastName);

        //    customer.Update(name, command.BirthDate);
        //    if (Valid)
        //        _customerRepository.Update(customer);

        //}

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Customer", "Customer already exists.");
                return null; 
            }

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, document, email, user);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);


            if (Valid)
                _customerRepository.Save(customer);
            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));

            return new RegistercustomerCommandResult
            {
                Id = customer.Id,
                Name = customer.Name.ToString()
            };
        }
    }
}
