using Enoca.Service.Products;

namespace Enoca.Api.Infrastructure.AppServiceInstallers.Products
{
    public class ProductCRUDServicesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductCommandsService, ProductCommandsService>();
            services.AddScoped<IProductQueriesService, ProductQueriesService>();
        }
    }
}
