using CozHep.Domain.Entities;
using System;

namespace CozHep.Domain.Interfaces
{
    public interface ICampaignRepository : IRepository<CampaingEntity>
    { 
        CampaingEntity GetByName(string name);

        CampaingEntity GetByProductCode(string code, DateTime parameterTime);
    }
}