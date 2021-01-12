using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.DTOs
{
    public class ExpenseDTO:BaseDTO
    {
        public decimal ExpenseAmount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
