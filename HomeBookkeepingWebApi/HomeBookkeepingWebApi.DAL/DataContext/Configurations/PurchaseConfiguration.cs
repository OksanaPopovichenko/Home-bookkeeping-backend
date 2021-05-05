using HomeBookkeepingWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBookkeepingWebApi.DAL.DataContext.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Price).IsRequired();
            builder.Property(d => d.UserEmail).IsRequired();
            builder.Property(d => d.Date).IsRequired();

            builder.HasOne(d => d.Category)
               .WithMany(s => s.Purchases)
               .HasForeignKey(d => d.CategoryId);
        }
    }
}