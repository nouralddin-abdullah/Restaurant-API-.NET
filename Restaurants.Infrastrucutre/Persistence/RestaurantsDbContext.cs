using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resuaurants.Domain.Entities;

namespace Restaurants.Infrastrucutre.Persistence;

public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<Resuaurants.Domain.Entities.Restaurants> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //To mark that adress is not sperate table and doesn't need a standalone pk
        modelBuilder.Entity<Resuaurants.Domain.Entities.Restaurants>().OwnsOne(r => r.Address);

        //Now let's do the one to many relationship with dishes
        modelBuilder.Entity<Resuaurants.Domain.Entities.Restaurants>().HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantsId);
    }
}
