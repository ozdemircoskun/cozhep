using CozHep.Domain.Entities;
using CozHep.Domain.Interfaces;
using CozHep.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CozHep.Infra.Data.Repository
{
    public class CampaignRepository : Repository<CampaingEntity>, ICampaignRepository
    {
        public CampaignRepository(CozHepContext context)
            : base(context)
        {

        }

        public CampaingEntity GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }


        public CampaingEntity GetByProductCode(string code, DateTime parameterTime)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.ProductCode == code && c.EndTime > parameterTime && c.BeginTime <= parameterTime);
        }
    }
}
