using CozHep.Domain.Commands;
using FluentValidation;
using System;

namespace CozHep.Domain.Validations
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {

        protected void ValidateProductCode()
        {
            RuleFor(c => c.ProductCode)
                .NotEmpty();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

    }
}