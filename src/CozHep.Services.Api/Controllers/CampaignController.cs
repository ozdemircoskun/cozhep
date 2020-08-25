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
    public class CampaignController : ApiController
    {
        private readonly ICampaignAppService _campaignAppService;

        public CampaignController(
            ICampaignAppService campaignAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _campaignAppService = campaignAppService;
        }
         

        [HttpGet]
        [AllowAnonymous]
        [Route("get-campaign-info/{name}")]
        public IActionResult Get(string name)
        {
            var viewModel = _campaignAppService.GetByName(name);

            return Response(viewModel);
        }

        [HttpPost] 
        [Route("create-campaign")]
        public IActionResult Post([FromBody] CampaignViewModel campaignViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(campaignViewModel);
            }

            _campaignAppService.Register(campaignViewModel);

            return Response(campaignViewModel);
        }

    

    }
}
