using STORE.DATA.Repository.Abstract;
using STORE.DTOs;
using STORE.ENTITY.Entities;
using STORE.EXCEPTION;
using STORE.Services.Abstract;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IUnitOfWork unitOfWork)
        {
            _expenseRepository = unitOfWork.Expenses;
            _unitOfWork = unitOfWork;
        }
        public async Task<ExpenseDTO> AddExpenseAsync(ExpenseDTO expenseDTO)
        {
            if (expenseDTO == null)
                throw new StoreApiException("Eksik ya da hatalı giriş yaptınız");
            var expenses = new Expense
            {
                Description = expenseDTO.Description,
                ExpenseAmount = expenseDTO.ExpenseAmount,
                InsertedDate = expenseDTO.InsertedDate,
                Name = expenseDTO.Name
            };
            await _expenseRepository.AddAsync(expenses).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return expenseDTO;
        }

        public async Task DeleteExpenseSizeAsync(int expenseId)
        {
            await _expenseRepository.DeleteAsync(expenseId).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        }

        public async Task<List<ExpenseDTO>> GetAllExpenseAsync()
        {
            var expenses = await _expenseRepository.GetAllAsync().ConfigureAwait(false);
            if (expenses == null)
                throw new StoreApiException("Kayıtlı hiçbir gider bulunamadı");
            var expensesDTO = expenses != null ?
                (from e in expenses
                 select new ExpenseDTO
                 {
                     Description = e.Description,
                     ExpenseAmount = e.ExpenseAmount,
                     InsertedDate = e.InsertedDate,
                     Id = e.Id,
                     Name = e.Name
                 }
                ).ToList() : null;

            return expensesDTO;
        }

        public async Task<ExpenseDTO> GetByIdExpenseAsync(int expenseId)
        {
            var expenses = await _expenseRepository.GetByIdAsync(expenseId).ConfigureAwait(false);
            if (expenses == null)
                throw new StoreApiException("İstenilen şirket bilgilerine ulaşılamadı");
            var expensesDTO = new ExpenseDTO
            {
                Description = expenses.Description,
                ExpenseAmount = expenses.ExpenseAmount,
                Id = expenses.Id,
                InsertedDate = expenses.InsertedDate,
                Name = expenses.Name
            };

            return expensesDTO;
        }

        public async Task<ExpenseDTO> UpdateExpenseAsync(ExpenseDTO expenseDTO)
        {
            var expenses = await _expenseRepository.GetByIdAsync(expenseDTO.Id).ConfigureAwait(false);
            if (expenses == null)
                throw new StoreApiException("Güncellenmek istenen gider bulunamadı");

            expenses.Name = expenseDTO.Name;
            expenses.ExpenseAmount = expenseDTO.ExpenseAmount;
            expenses.Description = expenseDTO.Description;

            _expenseRepository.Update(expenses);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return expenseDTO;
        }
    }
}
