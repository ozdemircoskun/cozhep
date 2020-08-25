using CozHep.Domain.Entities;

namespace CozHep.Domain.Interfaces
{
    public interface IParameterRepository : IRepository<ParameterEntity>
    {
        ParameterEntity GetByName(string name);
    }
}