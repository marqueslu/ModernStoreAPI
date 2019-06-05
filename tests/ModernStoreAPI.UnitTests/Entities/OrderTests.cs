using ModernStoreAPI.Domain.Entities;
using ModernStoreAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ModernStoreAPI.UnitTests.Entities
{
    public class OrderTests
    {
        private readonly Customer _customer;
        private readonly User _user;
        private readonly Product _mouse;
        private readonly Product _keyboard;
        private readonly Order _order;
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;

        public OrderTests()
        {
            _user = new User("lucasmarques", "123435", "123435");
            _name = new Name("Lucas", "Marques");
            _document = new Document("93149711045");
            _email = new Email("lucas.msilva09@gmail.com");
            _customer = new Customer(_name, _document, _email, _user);
            _mouse = new Product("Mouse", 300, "mouse.jpg", 0);
            _keyboard = new Product("Keyboard", 250, "keyboard.jpg", 20);
            _order = new Order(_customer, 8, 10);
        }
        [Fact]
        public void GivenAnOutOfStockProductItShouldreturnAnError()
        {
            _order.AddItem(new OrderItem(_mouse, 2));
            Assert.False(_order.Valid);
        }

        [Fact]
        public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
        {
            _order.AddItem(new OrderItem(_keyboard, 2));
            Assert.True(_keyboard.QuantityOnHand == 18);
        }

        [Fact]
        public void GivenAValidOrderTheTotalShouldBeValid()
        {
            _order.AddItem(new OrderItem(_keyboard, 1));
            var total = _order.Total();
            Assert.True(total == 248);
        }
    }
}
