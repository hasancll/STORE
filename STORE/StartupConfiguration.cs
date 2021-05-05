using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using STORE.DATA;
using STORE.DATA.Repository.Abstract;
using STORE.DATA.Repository.Concrate;
using STORE.Security.Token;
using STORE.Services.Abstract;
using STORE.Services.Concrate;
using STORE.UnitOfWork.Abstract;
using STORE.UnitOfWork.Concrate;
using System;

namespace STORE
{
    public static class StartupConfiguration
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
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISaleProductService, SaleProductService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Store", Version = "v1" });

                //x.OperationFilter<AddHeaderToSwagger>();

                x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new String[]{}
                    }
                });
            });
        }
    }
}
