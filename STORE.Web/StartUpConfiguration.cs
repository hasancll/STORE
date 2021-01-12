using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STORE.DATA;
using STORE.DATA.Repository.Abstract;
using STORE.DATA.Repository.Concrate;
using STORE.Services.Abstract;
using STORE.Services.Concrate;
using STORE.UnitOfWork.Abstract;
using STORE.UnitOfWork.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Web
{
    public static class StartUpConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(option => option.UseMySql(configuration["ConnectionStrings:LocalDatabase"].ToString(), o => { o.MigrationsAssembly("STORE"); }));
        }
        public static void ConfigureDependecyInjections(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IExpensesIncomesServices, ExpenseIncomesService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductColorService, ProductColorService>();
            services.AddScoped<IProductModelService, ProductModelService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<IUnitOfWork, _UnitOfWork>();
        }
    }
}
