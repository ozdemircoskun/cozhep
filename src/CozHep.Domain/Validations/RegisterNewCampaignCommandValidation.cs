using CozHep.Domain.Commands;

namespace CozHep.Domain.Validations
{
    public class RegisterNewCampaignCommandValidation : CampaignValidation<RegisterNewCampaignCommand>
    {
        public RegisterNewCampaignCommandValidation()
        { 
            ValidateName();
        }
    }
}