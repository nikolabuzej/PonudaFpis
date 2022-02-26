using Core.Abrstractions;
using Core.Domain.PonudjacAggregate;
using Core.Domain.PonudjacAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PonudjacRepository : IPonudjacRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Ponudjac> VratiPonudjaca(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
