using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop_back.DataAccess.Entities.Items;

namespace Shop_back.DataAccess.Configurations.Items
{
    public class SmartVariantsConfiguration : IEntityTypeConfiguration<SmartVariantsEntity>
    {
        public void Configure(EntityTypeBuilder<SmartVariantsEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Color)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Memory)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Storage)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Smart)
                .WithMany(x => x.Variants)
                .HasForeignKey(x => x.SmartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}