using CozHep.Domain.Validations;

namespace CozHep.Domain.Commands
{
    public class RegisterNewParameterCommand : ParameterCommand
    {
        public RegisterNewParameterCommand(string name, string value)
        {
            Name = name;
            Value = value; 
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewParameterCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}