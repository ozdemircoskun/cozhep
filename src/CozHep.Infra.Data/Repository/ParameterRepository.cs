using CozHep.Domain.Entities;
using CozHep.Domain.Interfaces;
using CozHep.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CozHep.Infra.Data.Repository
{
    public class ParameterRepository : Repository<ParameterEntity>, IParameterRepository
    {
        public ParameterRepository(CozHepContext context)
            : base(context)
        {

        }

        public ParameterEntity GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }
    }
}
