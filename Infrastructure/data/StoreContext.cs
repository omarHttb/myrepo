
using System.Reflection;
using API.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<product> Products { get; set;}

        public DbSet <ProductBrand> ProductBrands { get; set; }

        public DbSet <ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}