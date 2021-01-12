using STORE.DATA.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICompanyRepository Company { get; }
        IExpenseRepository Expenses { get; }
        IExpensesIncomeRepository ExpensesIncomes { get; }
        IPaymentTypeRepository PaymentTypies { get; }
        IProductCategoryRepository ProductCategories { get; }
        IProductColorRepository ProductColors { get; }
        IProductModelRepository ProductModels { get; }
        IProductSizeRepository  ProductSizes { get; }
        IProductStockRepository ProductStocks { get; }
        IReceiptPaymentRepository ReceiptPaymenties { get; }
        IReceiptRepository Receipties { get; }
        ISaleProductRepository SaleProducties { get; }
        Task SaveChangeAsync();

        void Commit();

    }
}
