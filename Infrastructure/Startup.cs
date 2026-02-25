using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        config.GetConnectionString("DefaultConnection"),
                        builder =>
                        {
                            builder.MigrationsHistoryTable("Migrations", "EFCore");
                            builder.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: new TimeSpan(0, 0, 0, 100), errorNumbersToAdd: [1]);
                        }
                    )
                ); 

        }
    }
}
