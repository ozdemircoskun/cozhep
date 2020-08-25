using CozHep.Domain.Commands;
using FluentValidation;
using System;

namespace CozHep.Domain.Validations
{
    public abstract class CampaignValidation<T> : AbstractValidator<T> where T : CampaignCommand
    {

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty();
        }
 

    }
}