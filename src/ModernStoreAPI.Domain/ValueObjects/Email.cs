using Flunt.Notifications;
using Flunt.Validations;

namespace ModernStoreAPI.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email", "Email must be valid"));
        }

        public string Address { get; private set; }
    }
}
