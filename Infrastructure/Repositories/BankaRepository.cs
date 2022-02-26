using Core.Abrstractions;
using Core.Domain.BankaAggregate;
using Core.Domain.BankaAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BankaRepository : IBankaRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Banka> VratiBanku(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
