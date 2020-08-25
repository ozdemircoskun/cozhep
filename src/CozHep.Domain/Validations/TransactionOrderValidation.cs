using CozHep.Domain.Commands;
using FluentValidation;
using System;

namespace CozHep.Domain.Validations
{
    public abstract class TransactionOrderValidation<T> : AbstractValidator<T> where T : TransactionOrderCommand
    {

        protected void ValidateProductName()
        {
            RuleFor(c => c.ProductCode)
                .NotEmpty();
        }
 

    }
}