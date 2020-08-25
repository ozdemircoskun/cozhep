using CozHep.Domain.Core.Events;
using System;

namespace CozHep.Domain.Events
{
    public class ProductRegisteredEvent : Event
    {
        public ProductRegisteredEvent(Guid id, string productCode, decimal price, int stock)
        {
            Id = id;
            ProductCode = productCode;
            Price = price;
            Stock = stock;
        }
        public Guid Id { get; set; }

        public string ProductCode { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

    }
}