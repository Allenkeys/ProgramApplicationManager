using Microsoft.EntityFrameworkCore;
using ProgramApplicationManager.Persistence;

namespace ProgramApplicationManager.API.Extensions
{
    public static class ServiceContainer
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseCosmos(
                    config.GetSection("DbConnection")["dburl"],
                    config.GetSection("DbConnection")["key"],
                    config.GetSection("DbConnection")["dbname"]
                );
            });
        }
    }
}
