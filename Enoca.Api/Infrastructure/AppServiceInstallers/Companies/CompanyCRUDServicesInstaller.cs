using Enoca.Service.Companies;

namespace Enoca.Api.Infrastructure.AppServiceInstallers.Companies
{
    public class CompanyCRUDServicesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICompanyCommandsService, CompanyCommandsService>();
            services.AddScoped<ICompanyQueriesService, CompanyQueriesService>();
        }
    }
}
