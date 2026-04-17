

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop_back.DataAccess.Entities.Product;

namespace Shop_back.DataAccess.Configurations.Product.ProductImage
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImageEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
        {
            builder.HasKey(pi => pi.ProductImageId);
            builder.HasOne(pi => pi.Product)
                   .WithMany(p => p.Images)
                   .HasForeignKey(pi => pi.ProductId);
            builder.Property(pi => pi.Urls)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(pi=> pi.Color)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
