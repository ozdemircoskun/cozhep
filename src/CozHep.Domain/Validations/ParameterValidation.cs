using CozHep.Domain.Commands;
using FluentValidation;
using System;

namespace CozHep.Domain.Validations
{
    public abstract class ParameterValidation<T> : AbstractValidator<T> where T : ParameterCommand
    {

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty();
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

    }
}