using CozHep.Domain.Entities;
using CozHep.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CozHep.Infra.Data.Context
{
    public class CozHepContext : DbContext
    {
        public CozHepContext(DbContextOptions<CozHepContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CampaingEntity> Campaings { get; set; }


        public DbSet<TransactionOrderEntity> TransactionOrders { get; set; }
        public DbSet<ParameterEntity> Parameters { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());

            modelBuilder.ApplyConfiguration(new CampaignMap());

            modelBuilder.ApplyConfiguration(new ParameterMap());

            modelBuilder.ApplyConfiguration(new TransactionOrderMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
