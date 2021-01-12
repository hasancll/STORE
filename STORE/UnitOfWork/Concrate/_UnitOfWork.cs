using STORE.DATA;
using STORE.DATA.Repository.Abstract;
using STORE.DATA.Repository.Concrate;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.UnitOfWork.Concrate
{
    public class _UnitOfWork : IUnitOfWork
    {
        #region Properties
        private readonly StoreContext _storeContext;
        private ProductRepository _productRepository;
        private CompanyRepository _companyRepository;
        private ExpenseRepository _expenseRepository;
        private ExpensesIncomesRepository _expensesIncomesRepository;
        private PaymentTypeRepository _paymentTypeRepository;
        private ProductCategoryRepository _productCategoryRepository;
        private ProductColorRepository _productColorRepository;
        private ProductModelRepository _productModelRepository;
        private ProductSizeRepository _productSizeRepository;
        private ProductStockRepository _productStockRepository;
        private ReceiptPaymentRepository _receiptPaymentRepository;
        private ReceiptRepository _receiptRepository;
        private SaleProductRepository _saleProductRepository;
        #endregion

        public _UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        #region Repository Implement
        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_storeContext);

        public ICompanyRepository Company => _companyRepository = _companyRepository ?? new CompanyRepository(_storeContext);

        public IExpenseRepository Expenses => _expenseRepository = _expenseRepository ?? new ExpenseRepository(_storeContext);

        public IExpensesIncomeRepository ExpensesIncomes => _expensesIncomesRepository = _expensesIncomesRepository ?? new ExpensesIncomesRepository(_storeContext);

        public IPaymentTypeRepository PaymentTypies => _paymentTypeRepository = _paymentTypeRepository ?? new PaymentTypeRepository(_storeContext);

        public IProductCategoryRepository ProductCategories => _productCategoryRepository = _productCategoryRepository ?? new ProductCategoryRepository(_storeContext);

        public IProductColorRepository ProductColors => _productColorRepository = _productColorRepository ?? new ProductColorRepository(_storeContext);

        public IProductModelRepository ProductModels => _productModelRepository = _productModelRepository ?? new ProductModelRepository(_storeContext);

        public IProductSizeRepository ProductSizes => _productSizeRepository = _productSizeRepository ?? new ProductSizeRepository(_storeContext);

        public IProductStockRepository ProductStocks => _productStockRepository = _productStockRepository ?? new ProductStockRepository(_storeContext);

        public IReceiptPaymentRepository ReceiptPaymenties => _receiptPaymentRepository = _receiptPaymentRepository ?? new ReceiptPaymentRepository(_storeContext);

        public IReceiptRepository Receipties => _receiptRepository = _receiptRepository ?? new ReceiptRepository(_storeContext);

        public ISaleProductRepository SaleProducties => _saleProductRepository = _saleProductRepository ?? new SaleProductRepository(_storeContext);

        #endregion

        public void Commit()
        {
            _storeContext.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            await _storeContext.SaveChangesAsync();
        }
    }
}
