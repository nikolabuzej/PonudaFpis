using Core.Abrstractions;
using Core.Domain.ProizvodAggregate;
using Core.Domain.ProizvodAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProizvodRepository : IProizvodRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Proizvod> VratiProizvod(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
