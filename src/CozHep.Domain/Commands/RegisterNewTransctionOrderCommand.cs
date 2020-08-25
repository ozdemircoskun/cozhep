using CozHep.Domain.Validations;
using System;

namespace CozHep.Domain.Commands
{
    public class RegisterNewTransctionOrderCommand : TransactionOrderCommand
    {
        public RegisterNewTransctionOrderCommand(string productCode, int quantity)
        {
             
            ProductCode = productCode; 
            Quantity = quantity;
           
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewTransactionOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}