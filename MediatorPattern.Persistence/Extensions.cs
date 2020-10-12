using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorPattern.Persistence
{
    public static class Extensions
    {
        public static void AddPersistence(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContextPool<ElementsContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}