using HomeBookkeepingWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBookkeepingWebApi.DAL.DataContext.Configurations
{
    public class BudgetPlanConfiguration : IEntityTypeConfiguration<BudgetPlan>
    {
        public void Configure(EntityTypeBuilder<BudgetPlan> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.UserEmail).IsRequired();
            builder.Property(d => d.StartDate).IsRequired();
            builder.Property(d => d.EndDate).IsRequired();
            builder.Property(d => d.TotalValue).IsRequired();
        }
    }
}