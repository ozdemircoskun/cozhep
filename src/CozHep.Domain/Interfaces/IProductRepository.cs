using CozHep.Domain.Entities;

namespace CozHep.Domain.Interfaces
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        ProductEntity GetByProductCode(string productCode);
    }
}