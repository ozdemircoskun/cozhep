using CozHep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozHep.Infra.Data.Mappings
{
    public class ParameterMap : IEntityTypeConfiguration<ParameterEntity>
    {
        public void Configure(EntityTypeBuilder<ParameterEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
             
        }
    }
}
