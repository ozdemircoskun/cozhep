using CozHep.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CozHep.Domain.EventHandlers
{
    public class ProductEventHandler :
        INotificationHandler<ProductRegisteredEvent>
    {
        public Task Handle(ProductRegisteredEvent message, CancellationToken cancellationToken)
        {
            // mail, sms, elasticsearch

            return Task.CompletedTask;
        }


    }
}