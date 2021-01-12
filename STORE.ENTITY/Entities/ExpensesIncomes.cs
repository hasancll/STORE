using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.ENTITY.Entities
{
    public class ExpensesIncomes:BaseEntity
    {
        public decimal ExpenseAmount { get; set; }
        public decimal IncomeAmount { get; set; }
    }
}
