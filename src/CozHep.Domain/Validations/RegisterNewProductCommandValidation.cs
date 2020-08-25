using CozHep.Domain.Commands;

namespace CozHep.Domain.Validations
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        { 
            ValidateProductCode();
        }
    }
}