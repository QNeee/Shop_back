using Microsoft.EntityFrameworkCore;
using Shop_back.DataAccess.Entities.Product;

namespace Shop_back.DataAccess
{
    public class ShopBackDbContext : DbContext
    {
        public ShopBackDbContext(DbContextOptions<ShopBackDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
    }

}