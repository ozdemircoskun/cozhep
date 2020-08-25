using CozHep.Domain.Validations;

namespace CozHep.Domain.Commands
{
    public class RegisterNewCampaignCommand : CampaignCommand
    {
        public RegisterNewCampaignCommand(string name, string productCode, int duration, int pmLimit, int targetSalesCount)
        {
            Name = name;
            ProductCode = productCode;
            Duration = duration;
            PmLimit  = pmLimit;
            TargetSalesCount = targetSalesCount;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCampaignCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}