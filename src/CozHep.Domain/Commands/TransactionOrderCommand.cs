using CozHep.Domain.Core.Commands;
using System;

namespace CozHep.Domain.Commands
{
    public abstract class TransactionOrderCommand : Command
    {
        public Guid Id { get; protected set; } 
        public string ProductCode { get; protected set; } 
        public int Quantity { get; protected set; }
 

    }
}