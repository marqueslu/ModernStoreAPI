using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Mappings
{
    public class OrderITemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Quantity);
            builder.HasOne(x => x.Product);
            //builder.OwnsOne()
        }
    }
}
