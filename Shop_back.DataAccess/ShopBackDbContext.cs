using Microsoft.EntityFrameworkCore;
using Shop_back.DataAccess.Entities.Category;
using Shop_back.DataAccess.Entities.Product;
using Shop_back.DataAccess.Entities.Product.ProductVariant;

namespace Shop_back.DataAccess
{
    public class ShopBackDbContext : DbContext
    {
        public ShopBackDbContext(DbContextOptions<ShopBackDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductVariantEntity> ProductVariants { get; set; }
        public DbSet<ProductImageEntity> ProductImages { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopBackDbContext).Assembly);
        }
    }


}