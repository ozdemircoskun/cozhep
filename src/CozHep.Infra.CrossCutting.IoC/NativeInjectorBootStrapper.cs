using CozHep.Application.Interfaces;
using CozHep.Application.Services;
using CozHep.Domain.CommandHandlers;
using CozHep.Domain.Commands;
using CozHep.Domain.Core.Bus;
using CozHep.Domain.Core.Notifications;
using CozHep.Domain.EventHandlers;
using CozHep.Domain.Events;
using CozHep.Domain.Interfaces;
using CozHep.Infra.CrossCutting.Bus;
using CozHep.Infra.Data.Context;
using CozHep.Infra.Data.Repository;
using CozHep.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CozHep.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<ICampaignAppService, CampaignAppService>();
            services.AddScoped<IParameterAppService, ParameterAppService>();
            services.AddScoped<ITransactionOrderAppService, TransactionOrderAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<CampaignRegisteredEvent>, CampaignEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewCampaignCommand, bool>, CampaignCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewParameterCommand, bool>, ParameterCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewTransctionOrderCommand, bool>, TransactionOrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateParameterCommand, bool>, ParameterCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, ProductCommandHandler>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();
            services.AddScoped<ITransactionOrderRepository, TransactionOrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CozHepContext>();


        }
    }
}