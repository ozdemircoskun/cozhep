using CozHep.Application.Interfaces;
using CozHep.Application.ViewModels;
using CozHep.Domain.Core.Bus;
using CozHep.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CozHep.Services.Api.Controllers
{ 
    public class TransactionOrderController : ApiController
    {
        private readonly ITransactionOrderAppService _transactionOrderAppService;

        public TransactionOrderController(
            ITransactionOrderAppService transactionOrderAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _transactionOrderAppService = transactionOrderAppService;
        }
         
         

        [HttpPost] 
        [Route("create-order")]
        public IActionResult Post([FromBody] TransactionOrderViewModel transactionOrderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(transactionOrderViewModel);
            }

            _transactionOrderAppService.Register(transactionOrderViewModel);

            return Response(transactionOrderViewModel);
        }

    

    }
}
