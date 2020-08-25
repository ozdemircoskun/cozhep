using AutoMapper;
using CozHep.Application.ViewModels;
using CozHep.Domain.Entities;

namespace CozHep.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductEntity, ProductViewModel>();
            CreateMap<CampaingEntity, CampaignViewModel>();
            CreateMap<CampaingEntity, CampaignDetailViewModel>();
            CreateMap<ParameterEntity, ParameterViewModel>();
            CreateMap<TransactionOrderEntity, TransactionOrderViewModel>();
        }
    }
}
