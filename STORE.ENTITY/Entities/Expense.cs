using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.ENTITY.Entities
{
    public class Expense:BaseEntity
    {
        public decimal ExpenseAmount { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
