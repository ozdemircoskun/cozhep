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
    public class TransactionOrderCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewTransctionOrderCommand, bool>
    {
        private readonly ITransactionOrderRepository _transactionOrderRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public TransactionOrderCommandHandler(ITransactionOrderRepository transactionOrderRepository,
                                      IParameterRepository parameterRepository,
                                      ICampaignRepository campaignRepository,
                                      IProductRepository productRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _transactionOrderRepository = transactionOrderRepository;
            _parameterRepository = parameterRepository;
            _campaignRepository = campaignRepository;
            _productRepository = productRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewTransctionOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
            var hourParameter = _parameterRepository.GetByName("InstantHour");
            var product = _productRepository.GetByProductCode(message.ProductCode);
            var productCampaign = _campaignRepository.GetByProductCode(message.ProductCode, Convert.ToDateTime(hourParameter.Value));

            if (productCampaign == null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Campaign not found!"));
                return Task.FromResult(false);
            }

            var transactionOrder = new TransactionOrderEntity(
                Guid.NewGuid(),
                productCampaign.Name,
                message.ProductCode,
                productCampaign.PmLimit,
                message.Quantity,
                product.Price,
                (product.Price * message.Quantity),
                ((product.Price * productCampaign.PmLimit) / 100),
                (((product.Price * productCampaign.PmLimit) / 100) * message.Quantity),
                Convert.ToDateTime(hourParameter.Value),
                DateTime.Now);


            _transactionOrderRepository.Add(transactionOrder);


            var productUpdate = new ProductEntity(product.Id, product.ProductCode, product.Price, (product.Stock - message.Quantity));
            _productRepository.Update(productUpdate);
             
            Commit();

            return Task.FromResult(true);
        }



        public void Dispose()
        {
            _campaignRepository.Dispose();
        }
    }
}