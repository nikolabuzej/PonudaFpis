using Core.Abrstractions;
using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.InformacijeOIsporuciAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InformacijeOIsporuciRepository : IInformacijeOIsporuciRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<InformacijeOIsporuci> VratiInformacijeOIsporuci(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
