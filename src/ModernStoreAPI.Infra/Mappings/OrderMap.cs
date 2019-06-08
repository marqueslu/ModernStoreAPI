using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.DeliveryFee).HasColumnType("money");
            builder.Property(x => x.Discount).HasColumnType("money");
            builder.Property(x => x.Number).IsRequired().HasMaxLength(8).IsFixedLength();
            builder.Property(x => x.Status);

            builder.HasMany(x => x.Items);
            builder.HasOne(x => x.Customer);

        }
    }
}
