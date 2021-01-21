using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class ExpensesIncomesDTO:BaseDTO
    {
        public decimal ExpenseAmount { get; set; }
        public decimal IncomeAmount { get; set; }
    }
}
