using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serdiuk.NoteApp.Appication.Common.Interfaces;
using Serdiuk.NoteApp.Infrastructure.Persistance;

namespace Serdiuk.NoteApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("DEV_APPLICATION_CONTEXT"));

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
