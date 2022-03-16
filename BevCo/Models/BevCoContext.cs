using Microsoft.EntityFrameworkCore;

namespace BevCo.Models
{
  public class BevCoContext : DbContext
  {
    public DbSet<Beverage> Beverages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryBeverage> CategoryBeverage { get; set; }
    

    public BevCoContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
