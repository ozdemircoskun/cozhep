using CozHep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozHep.Infra.Data.Mappings
{
    public class TransactionOrderMap : IEntityTypeConfiguration<TransactionOrderEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionOrderEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
             
        }
    }
}
