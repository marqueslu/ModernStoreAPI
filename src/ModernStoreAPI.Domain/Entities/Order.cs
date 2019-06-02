using Flunt.Validations;
using ModernStoreAPI.Domain.Enums;
using ModernStoreAPI.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernStoreAPI.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatuts.Created;
            _items = new List<OrderItem>();
            DeliveryFee = deliveryFee;
            Discount = discount;

            AddNotifications(new Contract()
                .IsGreaterThan(DeliveryFee, 0, "DeliveryFee", "Delivery fee must be greater than 0")
                .IsGreaterThan(Discount, -1, "Discount", "Discount must be greater than -1"));
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatuts Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => SubTotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if (item.Valid)
                _items.Add(item);
        }

        public void Place()
        {

        }
    }
}
