using Microsoft.AspNetCore.Http;
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

namespace STORE
{
    public static class StartupConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(option => option.UseMySql(configuration["ConnectionStrings:LocalDatabase"].ToString(), o => { o.MigrationsAssembly("STORE"); }));

            //services.AddIdentity<StoreApiUser, IdentityRole>();

            /*services.AddIdentity<MarketUser, MarketRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcçdefgğhiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-_.";

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
            }).AddPasswordValidator<PasswordValidation>().AddEntityFrameworkStores<MarketDbContext>().AddDefaultTokenProviders();*/
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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
