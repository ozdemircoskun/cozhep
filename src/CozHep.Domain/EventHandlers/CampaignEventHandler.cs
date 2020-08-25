using CozHep.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CozHep.Domain.EventHandlers
{
    public class CampaignEventHandler :
        INotificationHandler<CampaignRegisteredEvent>
    {
        public Task Handle(CampaignRegisteredEvent message, CancellationToken cancellationToken)
        {
            // mail, sms, elasticsearch

            return Task.CompletedTask;
        }


    }
}