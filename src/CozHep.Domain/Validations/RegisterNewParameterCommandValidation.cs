using CozHep.Domain.Commands;

namespace CozHep.Domain.Validations
{
    public class RegisterNewParameterCommandValidation : ParameterValidation<RegisterNewParameterCommand>
    {
        public RegisterNewParameterCommandValidation()
        { 
            ValidateName();
        }
    }
}