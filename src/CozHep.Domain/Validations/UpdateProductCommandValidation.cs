using CozHep.Domain.Commands;

namespace CozHep.Domain.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<ProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId(); 
        }
    }
}