using Microsoft.Extensions.DependencyInjection;
using Serdiuk.NoteApp.Appication.Common.Mapping;
using System.Reflection;

namespace Serdiuk.NoteApp.Appication
{
    public static class DependencyInjection
    {
        /// <returns>Services</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(o =>{
                o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(typeof(ApplicationMapper));

            return services;
        }
    }
}
