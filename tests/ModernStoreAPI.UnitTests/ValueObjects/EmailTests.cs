using ModernStoreAPI.Domain.ValueObjects;
using Xunit;

namespace ModernStoreAPI.UnitTests.ValueObjects
{
    public class EmailTests
    {
        private readonly Email _emailInvalid;

        public EmailTests()
        {
            _emailInvalid = new Email("teste.com");
        }

        [Fact]
        public void GivenAnInvalidemailShouldReturnANotification()
        {
            Assert.False(_emailInvalid.Valid);
        }
    }
}
