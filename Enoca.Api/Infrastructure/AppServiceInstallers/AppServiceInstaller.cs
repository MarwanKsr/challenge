using Enoca.Data.Base;

namespace Enoca.Api.Infrastructure.AppServiceInstallers
{
    public class AppServiceInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        }
    }
}
