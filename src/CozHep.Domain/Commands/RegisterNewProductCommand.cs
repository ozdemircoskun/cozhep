using CozHep.Domain.Validations;

namespace CozHep.Domain.Commands
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(string productCode, decimal price, int stock)
        {
            ProductCode = productCode;
            Price = price;
            Stock = stock;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}