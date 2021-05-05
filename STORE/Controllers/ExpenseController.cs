using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STORE.DTOs;
using STORE.MIDDLEWARE.StoreResponseHelper;
using STORE.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExpense()
        {
            var expenses = await _expenseService.GetAllExpenseAsync().ConfigureAwait(false);
            HttpContext.Items["message"] = "Giderler başarılı şekilde getirildi.";
            return Ok(expenses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdExpense(int id)
        {
            var expense = await _expenseService.GetByIdExpenseAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen gider başarılı bir şekilde getirildi.";
            return Ok(expense);
        }
        [HttpPost]
        public async Task<IActionResult> AddToExpense(ExpenseDTO expenseDTO)
        {
            var expense = await _expenseService.AddExpenseAsync(expenseDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen gider başarılı bir şekilde eklendi.";
            return Ok(expense);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateToExpense(ExpenseDTO expenseDTO)
        {
            var expense = await _expenseService.UpdateExpenseAsync(expenseDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen gider güncellendi.";
            return Ok(expense);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToExpense(int id)
        {
            await _expenseService.DeleteExpenseSizeAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen gider başarılı bir şekilde silindi.";
            return Ok();
        }
    }
}
