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
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(
            IProductAppService productAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _productAppService = productAppService;
        }
         

        [HttpGet]
        [AllowAnonymous]
        [Route("get-product-info/{productcode}")]
        public IActionResult Get(string productcode)
        {
            var viewModel = _productAppService.GetByProductCode(productcode);

            return Response(viewModel);
        }

        [HttpPost] 
        [Route("create-product")]
        public IActionResult Post([FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _productAppService.Register(productViewModel);

            return Response(productViewModel);
        }

    

    }
}
