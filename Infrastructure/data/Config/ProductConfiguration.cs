using API.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<product>
    {
        public void Configure(EntityTypeBuilder<product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property (p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany()
             .HasForeignKey(p => p.ProductBrandId);
              builder.HasOne(t => t.ProductType).WithMany()
              .HasForeignKey(p => p.ProductTypeId);
        }
    }
}