using CozHep.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CozHep.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Register(ProductViewModel viewModel);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
        ProductViewModel GetByProductCode(string productcode);
        void Update(ProductViewModel viewModel);
        void Remove(Guid id);

    }
}
