using CozHep.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CozHep.Application.Interfaces
{
    public interface ICampaignAppService : IDisposable
    {
        void Register(CampaignViewModel viewModel);
        IEnumerable<CampaignViewModel> GetAll();
        CampaignViewModel GetById(Guid id);
        CampaignDetailViewModel GetByName(string name);
        void Update(CampaignViewModel viewModel);
        void Remove(Guid id);

    }
}
