using CozHep.Domain.Entities;
using CozHep.Domain.Interfaces;
using CozHep.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CozHep.Infra.Data.Repository
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(CozHepContext context)
            : base(context)
        {

        }

        public ProductEntity GetByProductCode(string productCode)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.ProductCode == productCode);
        }
    }
}
