using CozHep.Domain.Core.Entities;
using System;

namespace CozHep.Domain.Entities
{
    public class ProductEntity : Entity
    {
        public ProductEntity(Guid id, string productCode, decimal price, int stock)
        {
            Id = id;
            ProductCode = productCode;
            Price = price;
            Stock = stock;
        }

        // Empty constructor for EF
        protected ProductEntity() { }
        public string ProductCode { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
    }
}