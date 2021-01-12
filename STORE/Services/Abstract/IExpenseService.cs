using STORE.DATA.Repository.Abstract;
using STORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IExpenseService
    {
        Task<ExpenseDTO> AddExpenseAsync(ExpenseDTO expenseDTO);
        Task<ExpenseDTO> UpdateExpenseAsync(ExpenseDTO expenseDTO);
        Task DeleteExpenseSizeAsync(int expenseId);
        Task<List<ExpenseDTO>> GetAllExpenseAsync();
        Task<ExpenseDTO> GetByIdExpenseAsync(int expenseId);
    }
}
