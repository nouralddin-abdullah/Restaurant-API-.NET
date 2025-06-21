using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restaurants.Infrastrucutre.Persistence;
using Restaurants.Infrastrucutre.Repositories;
using Restaurants.Infrastrucutre.Seeders;
using Resuaurants.Domain.Entities;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Infrastrucutre.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var ConnectionString = configuration.GetConnectionString("RestaurantsDb");
        services.AddDbContext<RestaurantsDbContext>(Options => Options
        .UseSqlServer(ConnectionString)
        .EnableSensitiveDataLogging());

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();


        //Dependency Injection to the repositories of the entities
        services.AddScoped<IRestaurantsRepository, RestaurantsRepositories>();
    }
}
