using BankSphere.Domain.Interfaces;
using BankSphere.Infrastructure.Interfaces;
using BankSphere.Infrastructure.Interfaces.Repositories;
using BankSphere.Infrastructure.Repositories.Domain;
using BankSphere.Infrastructure.Repositories.Query;
using BankSphere.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BankSphere.Infrastructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<InfrastructureSettings>(configuration);

            services.AddTransient<IInfrastructureSettings>(service =>
            {
                IOptions<InfrastructureSettings> options = service.GetService<IOptions<InfrastructureSettings>>();
                return options.Value;
            });

            services.AddTransient<IBusinessClientRepository, BusinessClientRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddScoped<IQueryClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IQueryProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IQueryClientsHighestBalanceRepository, QueryClientsHighestBalanceRepository>();
            services.AddScoped<IQueryAverageBalanceByTypeRepository, QueryAverageBalanceByTypeRepository>();

            return services;

        }
    }
}
