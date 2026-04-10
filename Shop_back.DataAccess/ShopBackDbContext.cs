using Microsoft.EntityFrameworkCore;
using Shop_back.DataAccess.Entities.Items;

namespace Shop_back.DataAccess
{
    public class ShopBackDbContext : DbContext
    {
        public ShopBackDbContext(DbContextOptions<ShopBackDbContext> options)
            : base(options)
        {

        }
        public DbSet<SmartEntity> Smarts { get; set; }
        public DbSet<SmartVariantsEntity> SmartVariants { get; set; }
    }

}