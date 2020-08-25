using CozHep.Domain.Commands;

namespace CozHep.Domain.Validations
{
    public class RegisterNewTransactionOrderCommandValidation : TransactionOrderValidation<RegisterNewTransctionOrderCommand>
    {
        public RegisterNewTransactionOrderCommandValidation()
        { 
            ValidateProductName();
        }
    }
}