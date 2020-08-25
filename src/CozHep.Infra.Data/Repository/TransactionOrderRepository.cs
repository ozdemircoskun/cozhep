using CozHep.Domain.Entities;
using CozHep.Domain.Interfaces;
using CozHep.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CozHep.Infra.Data.Repository
{
    public class TransactionOrderRepository : Repository<TransactionOrderEntity>, ITransactionOrderRepository
    {
        public TransactionOrderRepository(CozHepContext context)
            : base(context)
        {

        }
         
    }
}
