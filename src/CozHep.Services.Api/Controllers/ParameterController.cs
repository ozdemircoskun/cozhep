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
    public class ParameterController : ApiController
    {
        private readonly IParameterAppService _parameterAppService;

        public ParameterController(
            IParameterAppService parameterAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _parameterAppService = parameterAppService;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("get-parameter-info/{name}")]
        public IActionResult Get(string name)
        {
            var viewModel = _parameterAppService.GetByName(name);

            return Response(viewModel);
        }

        [HttpPost]
        [Route("create-default-parameter")]
        public IActionResult Post()
        {
            ParameterViewModel parameterViewModel = new ParameterViewModel();
            parameterViewModel.Name = "InstantHour";
            parameterViewModel.Value = DateTime.Today.ToString();

            _parameterAppService.Register(parameterViewModel);

            return Response(parameterViewModel);
        }

        [HttpPost]
        [Route("increase_time")]
        public IActionResult Post(int value)
        {

            var viewModel = _parameterAppService.GetByName("InstantHour");

            viewModel.Value = DateTime.Today.AddHours(Convert.ToInt32(value)).ToString();
            _parameterAppService.Update(viewModel);

            return Response(viewModel);
        }
    }
}
