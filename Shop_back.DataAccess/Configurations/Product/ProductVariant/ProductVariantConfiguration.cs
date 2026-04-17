

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop_back.DataAccess.Entities.Product.ProductVariant;

namespace Shop_back.DataAccess.Configurations.Product.ProductVariant
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariantEntity>
    {
        public void Configure(EntityTypeBuilder<ProductVariantEntity> builder)
        {
            builder.HasKey(pv => pv.ProductVariantId);
            builder.Property(pv => pv.StorageGb).IsRequired();
            builder.Property(pv => pv.MemoryGb).IsRequired();
            builder.Property(pv => pv.Stock).IsRequired();
            builder.Property(pv => pv.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(pv => pv.DiscountPercent).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.HasOne(pv => pv.Product)
    .WithMany(p => p.Variants)
    .HasForeignKey(pv => pv.ProductId)
    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
