

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop_back.Core.Models.Items;
using Shop_back.DataAccess.Entities.Items;

namespace Shop_back.DataAccess.Configurations.Items
{
    public class SmartConfiguration : IEntityTypeConfiguration<SmartEntity>
    {
        public void Configure(EntityTypeBuilder<SmartEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(Smart.MaxStrLength).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(Smart.MaxStrLength).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
