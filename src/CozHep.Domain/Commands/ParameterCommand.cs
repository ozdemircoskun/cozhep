using CozHep.Domain.Core.Commands;
using System;

namespace CozHep.Domain.Commands
{
    public abstract class ParameterCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Value { get; protected set; }
 

    }
}