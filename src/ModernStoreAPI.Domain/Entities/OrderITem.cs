using Flunt.Validations;
using ModernStoreAPI.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem()
        {

        }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            AddNotifications(new Contract()
               .IsGreaterThan(Quantity, 0, "Quantity", "Quantity must be greater than 0.")
               .IsGreaterOrEqualsThan(Product.QuantityOnHand, Quantity + 1, "QuantityOnHand", "Quantity on hand must be greater or equal than quantity of the order."));

            Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
