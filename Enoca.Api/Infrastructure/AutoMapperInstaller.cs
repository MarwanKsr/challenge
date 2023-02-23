namespace Enoca.Api.Infrastructure
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(GetType());
        }
    }
}
