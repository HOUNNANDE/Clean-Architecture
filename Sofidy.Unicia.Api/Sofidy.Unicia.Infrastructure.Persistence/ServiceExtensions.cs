using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context.Interfaces;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace Sofidy.Unicia.Infrastructure.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureContext(configuration)
                    .ConfigureTypeAsInterfaceFromAssembly(namespaceTarget: "Infrastructure.Persistence.DAL.Repositories",
                                                               baseOnType: new[] { typeof(BaseRepository<,>) },
                                                               isBaseOnGenericType: true); 

            return services;
        }

        public static IServiceCollection ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Unicia Import
            var connectionStringUniciaImport = configuration.GetConnectionString("UniciaImport");
            if (!string.IsNullOrEmpty(connectionStringUniciaImport))
                services.AddDbContext<UniciaImportContext>(opt => opt.UseSqlServer(connectionStringUniciaImport));
            services.AddScoped<IUnitOfWorkUniciaImport, UnitOfWorkUnciaImport>();

            // Unicia
            var connectionStringUnicia = configuration.GetConnectionString("Unicia"); 
            if(!string.IsNullOrEmpty(connectionStringUnicia))
                services.AddDbContext<UniciaContext>(opt => opt.UseSqlServer(connectionStringUnicia));
            services.AddScoped<IUnitOfWorkUnicia, UnitOfWorkUnicia>();


            return services;
        }  
    }
}