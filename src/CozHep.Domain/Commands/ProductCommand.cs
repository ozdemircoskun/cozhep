using CozHep.Domain.Core.Commands;
using System;

namespace CozHep.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string ProductCode { get; protected set; }
        public decimal Price { get; protected set; }
        public int Stock { get; protected set; }

    }
}