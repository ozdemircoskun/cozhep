using System;
using CozHep.Domain.Validations;

namespace CozHep.Domain.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string productCode, decimal price, int stock)
        {
            Id = id;
            ProductCode = productCode;
            Price = price;
            Stock = stock;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}