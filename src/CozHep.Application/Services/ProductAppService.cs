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
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductAppService(IMapper mapper,
                                  IProductRepository productRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            Bus = bus;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _productRepository.GetAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }
        public ProductViewModel GetByProductCode(string productcode)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetByProductCode(productcode));
        }
        public void Register(ProductViewModel viewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(viewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ProductViewModel viewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(viewModel);
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
