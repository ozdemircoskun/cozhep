using AutoMapper;
using CozHep.Application.ViewModels;
using CozHep.Domain.Commands;

namespace CozHep.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(c => new RegisterNewProductCommand(c.ProductCode, c.Price, c.Stock));

            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(c.Id, c.ProductCode,c.Price,c.Stock));
               
            CreateMap<CampaignViewModel, RegisterNewCampaignCommand>()
                  .ConstructUsing(c => new RegisterNewCampaignCommand(c.Name, c.ProductCode, c.Duration, c.PmLimit, c.TargetSalesCount));

            CreateMap<ParameterViewModel, RegisterNewParameterCommand>()
                  .ConstructUsing(c => new RegisterNewParameterCommand(c.Name, c.Value));


            CreateMap<ParameterViewModel, UpdateParameterCommand>()
            .ConstructUsing(c => new UpdateParameterCommand(c.Id, c.Name, c.Value));

            CreateMap<TransactionOrderViewModel, RegisterNewTransctionOrderCommand>()
                 .ConstructUsing(c => new RegisterNewTransctionOrderCommand(c.ProductCode, c.Quantity));

        

        }
    }
}
