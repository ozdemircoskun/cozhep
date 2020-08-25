using AutoMapper;
using AutoMapper.QueryableExtensions;
using CozHep.Application.Interfaces;
using CozHep.Application.ViewModels;
using CozHep.Domain.Commands;
using CozHep.Domain.Core.Bus;
using CozHep.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CozHep.Application.Services
{
    public class ParameterAppService : IParameterAppService
    {
        private readonly IMapper _mapper;
        private readonly IParameterRepository _parameterRepository;
        private readonly IMediatorHandler Bus;

        public ParameterAppService(IMapper mapper,
                                  IParameterRepository parameterRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _parameterRepository = parameterRepository;
            Bus = bus;
        }

        public IEnumerable<ParameterViewModel> GetAll()
        {
            return _parameterRepository.GetAll().ProjectTo<ParameterViewModel>(_mapper.ConfigurationProvider);
        }

        public ParameterViewModel GetById(Guid id)
        {
            return _mapper.Map<ParameterViewModel>(_parameterRepository.GetById(id));
        }
        public ParameterViewModel GetByName(string name)
        {
            return _mapper.Map<ParameterViewModel>(_parameterRepository.GetByName(name));
        }
        public void Register(ParameterViewModel viewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewParameterCommand>(viewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ParameterViewModel viewModel)
        {
            var updateCommand = _mapper.Map<UpdateParameterCommand>(viewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    
    }
}
