using CozHep.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CozHep.Application.Interfaces
{
    public interface ITransactionOrderAppService : IDisposable
    {
        void Register(TransactionOrderViewModel viewModel);
      
    }
}
