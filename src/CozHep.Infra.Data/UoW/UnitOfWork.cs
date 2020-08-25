using CozHep.Domain.Interfaces;
using CozHep.Infra.Data.Context;

namespace CozHep.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CozHepContext _context;

        public UnitOfWork(CozHepContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
