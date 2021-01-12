using STORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IExpensesIncomesServices
    {
        Task<List<ExpensesIncomesDTO>> GetAllExpensesIncomesAsync();
        
    }
}
