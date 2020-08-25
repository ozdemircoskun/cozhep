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
    public class TransactionOrderAppService : ITransactionOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionOrderRepository _transactionOrderRepository;
        private readonly IMediatorHandler Bus;

        public TransactionOrderAppService(IMapper mapper,
                                  ITransactionOrderRepository transactionOrderRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _transactionOrderRepository = transactionOrderRepository;
            Bus = bus;
        }
   
        public void Register(TransactionOrderViewModel viewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewTransctionOrderCommand>(viewModel);
            Bus.SendCommand(registerCommand);
        }

       
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    
    }
}
