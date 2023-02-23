using Enoca.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Enoca.Api.Infrastructure
{
    public class DbContextsInstaller : IInstaller
    {
        const string DEFAULT_CONNECTION_STRING_CONFIGURATION_PATH = "ConnectionStrings:DefaultConnection";
        const string DATABASE_PROVIDER_CONFIGURATION_PATH = "ConnectionStrings:Provider";
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>(DEFAULT_CONNECTION_STRING_CONFIGURATION_PATH);
            var provider = configuration.GetValue(DATABASE_PROVIDER_CONFIGURATION_PATH, "SqlServer");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
