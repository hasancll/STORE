using STORE.DATA.Repository.Abstract;
using STORE.DATA.Repository.Concrate;
using STORE.DTOs;
using STORE.Services.Abstract;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class ExpenseIncomesService : IExpensesIncomesServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpensesIncomeRepository _expensesIncomesRepository;
        public ExpenseIncomesService(IUnitOfWork unitOfWork)
        {
            _expensesIncomesRepository = unitOfWork.ExpensesIncomes;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ExpensesIncomesDTO>> GetAllExpensesIncomesAsync()
        {
            var expensesIncomes = await _expensesIncomesRepository.GetAllAsync().ConfigureAwait(false);

            var expensesIncomesDTO = expensesIncomes != null ?
                (from e in expensesIncomes
                 select new ExpensesIncomesDTO
                 {
                     ExpenseAmount = e.ExpenseAmount,
                     Id = e.Id,
                     IncomeAmount = e.IncomeAmount,
                     InsertedDate = e.InsertedDate
                 }
                 ).ToList() : null;

            return expensesIncomesDTO;
        }
    }
}
