
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
    }
}