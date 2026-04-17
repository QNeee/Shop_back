using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop_back.DataAccess.Entities.Category;

namespace Shop_back.DataAccess.Configurations.Category
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId)
        .ValueGeneratedOnAdd();

            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasMany(x => x.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}