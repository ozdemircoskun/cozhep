using CozHep.Domain.Commands;

namespace CozHep.Domain.Validations
{
    public class UpdateParameterCommandValidation : ParameterValidation<ParameterCommand>
    {
        public UpdateParameterCommandValidation()
        {
            ValidateId(); 
        }
    }
}