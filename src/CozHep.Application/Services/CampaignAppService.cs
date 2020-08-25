using AutoMapper;
using AutoMapper.QueryableExtensions;
using CozHep.Application.Interfaces;
using CozHep.Application.ViewModels;
using CozHep.Domain.Commands;
using CozHep.Domain.Core.Bus;
using CozHep.Domain.Interfaces;
using CozHep.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CozHep.Application.Services
{
    public class CampaignAppService : ICampaignAppService
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ITransactionOrderRepository _transactionOrderRepository;
        private readonly IMediatorHandler Bus;

        public CampaignAppService(IMapper mapper,
                                  ICampaignRepository campaignRepository,
                                  ITransactionOrderRepository  transactionOrderRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _transactionOrderRepository = transactionOrderRepository;
            _campaignRepository = campaignRepository;
            Bus = bus;
        }

        public IEnumerable<CampaignViewModel> GetAll()
        {
            return _campaignRepository.GetAll().ProjectTo<CampaignViewModel>(_mapper.ConfigurationProvider);
        }

        public CampaignViewModel GetById(Guid id)
        {
            return _mapper.Map<CampaignViewModel>(_campaignRepository.GetById(id));
        }
        public CampaignDetailViewModel GetByName(string name)
        {
            var campaignDetailViewModel = _mapper.Map<CampaignDetailViewModel>(_campaignRepository.GetByName(name));

            campaignDetailViewModel.TotalSalesCount = _transactionOrderRepository.GetAll().Where(o => o.CampaignName == name).Sum(o => o.Quantity);

            return campaignDetailViewModel;
        }
        public void Register(CampaignViewModel viewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCampaignCommand>(viewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CampaignViewModel viewModel)
        {

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
