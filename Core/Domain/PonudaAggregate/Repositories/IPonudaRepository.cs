using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.PonudaAggregate.Repositories
{
    public interface IPonudaRepository
    {
        public Task<Ponuda> VratiPonudu(Guid id);
        public Task KreirajPonudu(Ponuda ponuda);
        public Task AzurirajPonudu(Ponuda ponuda);
        public Task IzbrisiPonudu(Guid id);
    } 
}
