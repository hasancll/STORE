using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    public class ExpenseIncomesConfiguration:BaseConfiguration<ExpensesIncomes>
    {
        public override void Configure(EntityTypeBuilder<ExpensesIncomes> builder)
        {
            builder.Property(ex => ex.ExpenseAmount).HasColumnType("decimal(18,2)");
            builder.Property(ex => ex.IncomeAmount).HasColumnType("decimal(18,2)");
            base.Configure(builder);
        }
    }
}
