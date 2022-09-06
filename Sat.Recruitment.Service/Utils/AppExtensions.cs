using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Data;

namespace Sat.Recruitment.Service.Utils
{
    public static class AppExtensions
    {
        public static IServiceCollection SetUpAppDependencies(this IServiceCollection serviceCollection,
            string connectionString)
        {
            serviceCollection.AddDbContext<ApplicationDBContext>(options => options.UseSqlite(connectionString));
            return serviceCollection;
        }
    }
}