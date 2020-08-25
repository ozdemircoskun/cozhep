using CozHep.Domain.Core.Entities;
using System;

namespace CozHep.Domain.Entities
{
    public class ParameterEntity : Entity
    {
        public ParameterEntity(Guid id, string name, string value)
        {
            Id = id;
            Name = name;
            Value = value; 
        }

        // Empty constructor for EF
        protected ParameterEntity() { }
        public string Name { get; private set; }
        public string Value { get; private set; } 
    }
}