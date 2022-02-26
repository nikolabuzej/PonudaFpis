using Core.Abrstractions;
using Core.Domain.JavniPozivAggregate;
using Core.Domain.JavniPozivAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class JavniPozivRepository : IJavniPozivRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<JavniPoziv> VratiJavniPoziv(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
