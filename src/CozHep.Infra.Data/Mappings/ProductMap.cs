using CozHep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozHep.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.ProductCode)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
             
        }
    }
}
