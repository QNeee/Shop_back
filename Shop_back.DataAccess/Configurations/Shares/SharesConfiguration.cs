using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop_back.DataAccess.Entities.Shares;

namespace Shop_back.DataAccess.Configurations.Shares
{
    internal class SharesConfiguration : IEntityTypeConfiguration<SharesEntity>
    {
        public void Configure(EntityTypeBuilder<SharesEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.VariantId).IsRequired();
            builder.Property(x => x.Discount).IsRequired();
        }
    }
}
