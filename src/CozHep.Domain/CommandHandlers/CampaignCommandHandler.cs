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
    public class CampaignCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCampaignCommand, bool>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMediatorHandler Bus;

        public CampaignCommandHandler(ICampaignRepository campaignRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _campaignRepository = campaignRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewCampaignCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
             

            var campaing = new CampaingEntity(Guid.NewGuid(), message.Name, message.ProductCode, message.Duration, message.PmLimit, message.TargetSalesCount, DateTime.Today, DateTime.Today.AddHours(message.Duration));

            if (_campaignRepository.GetByName(campaing.Name) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Name  has already been taken."));
                return Task.FromResult(false);
            }

            _campaignRepository.Add(campaing);

            if (Commit())
            {
                Bus.RaiseEvent(new CampaignRegisteredEvent(campaing.Id, campaing.Name, campaing.ProductCode, campaing.Duration, campaing.PmLimit, campaing.TargetSalesCount));
            }

            return Task.FromResult(true);
        }



        public void Dispose()
        {
            _campaignRepository.Dispose();
        }
    }
}