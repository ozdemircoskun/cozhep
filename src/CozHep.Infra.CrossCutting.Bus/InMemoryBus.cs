using CozHep.Domain.Core.Bus;
using CozHep.Domain.Core.Commands;
using CozHep.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace CozHep.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator; 

        public InMemoryBus(IMediator mediator)
        { 
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        { 
            return _mediator.Publish(@event);
        }
    }
}