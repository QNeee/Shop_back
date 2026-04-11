

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop_back.DataAccess.Entities.Product;
using Shop_back.DataAccess.Repositories.Product;

namespace Shop_back.DataAccess.Configurations.Items
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {

        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(ProductRepositoryHelper.Max_Length_STR).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(ProductRepositoryHelper.Max_Length_STR).IsRequired();
        }
    }
}
