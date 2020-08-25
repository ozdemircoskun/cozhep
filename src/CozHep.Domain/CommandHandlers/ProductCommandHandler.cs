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
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductCommandHandler(IProductRepository productRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            Bus = bus;
        }


        public Task<bool> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var product = new ProductEntity(message.Id, message.ProductCode, message.Price, message.Stock);
            _productRepository.Update(product);

            Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var product = new ProductEntity(Guid.NewGuid(), message.ProductCode, message.Price, message.Stock);

            if (_productRepository.GetByProductCode(product.ProductCode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The ProductCode  has already been taken."));
                return Task.FromResult(false);
            }

            _productRepository.Add(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRegisteredEvent(product.Id, product.ProductCode, product.Price, product.Stock));
            }

            return Task.FromResult(true);
        }



        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}