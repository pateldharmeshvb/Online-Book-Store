using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookstore.Application.Interfaces;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Infrastructure.Persistence.Contexts;
using OnlineBookstore.Infrastructure.Persistence.Repositories;
using OnlineBookstore.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IBookRepositoryAsync, ProductRepositoryAsync>();
            #endregion
        }
    }
}
