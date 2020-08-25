using CozHep.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CozHep.Application.Interfaces
{
    public interface IParameterAppService : IDisposable
    {
        void Register(ParameterViewModel viewModel);
        IEnumerable<ParameterViewModel> GetAll();
        ParameterViewModel GetById(Guid id);
        ParameterViewModel GetByName(string name);
        void Update(ParameterViewModel viewModel);
        void Remove(Guid id);

    }
}
