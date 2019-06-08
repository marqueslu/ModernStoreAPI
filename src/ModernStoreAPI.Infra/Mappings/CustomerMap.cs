using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BirthDate);
            builder.OwnsOne(x => x.Document, document =>
            {
                document.Property(d => d.Number).IsRequired().HasMaxLength(11).IsFixedLength().HasColumnName("Document");
            });
            builder.OwnsOne(x => x.Document).Ignore(d => d.Notifications);
            //builder.Property(x => x.Document.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Address).IsRequired().HasMaxLength(160).HasColumnName("Email") ;
            });
            builder.OwnsOne(x => x.Email).Ignore(e => e.Notifications);
            //builder.Property(x => x.Email.Address).IsRequired().HasMaxLength(160);
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.FirstName).IsRequired().HasMaxLength(60).HasColumnName("FirstName");
                name.Property(x => x.LastName).IsRequired().HasMaxLength(60).HasColumnName("LastName");
            });
            builder.OwnsOne(x => x.Name).Ignore(n => n.Notifications);
            //builder.OwnsOne(x => x.User, user =>
            //{
            //    user.Property(x => x.Username).IsRequired().HasMaxLength(20);
            //    user.Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            //    user.Property(x => x.Active);
            //});
            builder.HasOne(x => x.User);
            //builder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            //builder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            //builder.Property(x => x.User.Username).IsRequired().HasMaxLength(20);
            //builder.Property(x => x.User.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            //builder.Property(x => x.User.Active);

        }
    }
}
