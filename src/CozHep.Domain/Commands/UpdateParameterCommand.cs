using System;
using CozHep.Domain.Validations;

namespace CozHep.Domain.Commands
{
    public class UpdateParameterCommand : ParameterCommand
    {
        public UpdateParameterCommand(Guid id, string name, string value)
        {
            Id = id;
            Name = name;
            Value = value; 
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateParameterCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}