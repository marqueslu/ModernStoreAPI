using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.ValueObjects;
using Xunit;

namespace ModernStoreAPI.UnitTests.Entities
{
    public class NameTests
    {
        private readonly Name _firstNameInvalid;
        private readonly Name _lastNameInvalid;

        public NameTests()
        {
            _firstNameInvalid = new Name("", "Marques");
            _lastNameInvalid = new Name("Lucas", "");
        }

        [Fact]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            Assert.False(_firstNameInvalid.Valid);
        }

        [Fact]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            Assert.False(_lastNameInvalid.Valid);
        }
    }
}
