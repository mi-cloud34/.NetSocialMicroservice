using Follow.DataAcess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Follow.DataAcess
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddDbContext<FollowDbContext>(options =>
                                                     options.UseNpgsql(
                                                         configuration.GetConnectionString("MessageDb")));
           
            return services;
        }

    }
}
