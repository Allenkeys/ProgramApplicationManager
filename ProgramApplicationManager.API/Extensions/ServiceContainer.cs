using Microsoft.EntityFrameworkCore;
using ProgramApplicationManager.Domain.Entities;
using ProgramApplicationManager.Persistence;
using ProgramApplicationManager.Persistence.Repositories;
using ProgramApplicationManager.Services.Implements;
using ProgramApplicationManager.Services.Interfaces;

namespace ProgramApplicationManager.API.Extensions
{
    public static class ServiceContainer
    {
        public static async Task<IServiceCollection> InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProgramService, ProgramService>();

            return await Task.FromResult(services);
        }

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

        public static async Task SeedDatabase(this WebApplication app)
        {
            var context = app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _ = context.Database.EnsureCreated();

            var anyUsers = context.Users.FirstOrDefault();

            if (anyUsers != null)
                return;

            await context.Users.AddRangeAsync(new List<User>()
            {
                new User
                {
                    Email = "klamar@gmail.com",
                    FirstName = "Kendrick",
                    LastName = "Lamar"
                },
                new User
                {
                   Email = "davido@gmail.com",
                   FirstName = "David",
                   LastName = "Adeleke"
                }
            })
                .ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
