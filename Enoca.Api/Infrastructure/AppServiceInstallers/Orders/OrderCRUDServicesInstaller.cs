using Enoca.Service.Orders;

namespace Enoca.Api.Infrastructure.AppServiceInstallers.Orders
{
    public class OrderCRUDServicesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderCommandService, OrderCommandService>();
            services.AddScoped<IOrderQueriesService, OrderQueriesService>();
        }
    }
}
