using CozHep.Domain.Commands;
using CozHep.Domain.Core.Bus;
using CozHep.Domain.Core.Notifications;
using CozHep.Domain.Entities;
using CozHep.Domain.Events;
using CozHep.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CozHep.Domain.CommandHandlers
{
    public class ParameterCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewParameterCommand, bool>,
        IRequestHandler<UpdateParameterCommand, bool>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMediatorHandler Bus;

        public ParameterCommandHandler(IParameterRepository parameterRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _parameterRepository = parameterRepository;
            Bus = bus;
        }
        public Task<bool> Handle(UpdateParameterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var parameter = new ParameterEntity(message.Id, message.Name, message.Value);
            _parameterRepository.Update(parameter);

            Commit();

            return Task.FromResult(true);
        }


        public Task<bool> Handle(RegisterNewParameterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var parameter = new ParameterEntity(Guid.NewGuid(), message.Name, message.Value);

            if (_parameterRepository.GetByName(parameter.Name) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Name has already been taken."));
                return Task.FromResult(false);
            }

            _parameterRepository.Add(parameter);

            Commit();
            

            return Task.FromResult(true);
        }



        public void Dispose()
        {
            _parameterRepository.Dispose();
        }
    }
}