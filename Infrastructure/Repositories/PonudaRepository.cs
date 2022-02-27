using Core.Abrstractions;
using Core.Domain.PonudaAggregate;
using Core.Domain.PonudaAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PonudaRepository : IPonudaRepository
    {
        private readonly PonudaDbContext _context;

        public PonudaRepository(PonudaDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task AzurirajPonudu(Ponuda ponuda)
        {
            _context.Ponuda.Update(ponuda);

            return Task.CompletedTask;
        }

        public Task IzbrisiPonudu(Ponuda ponuda)
        {
            _context.Ponuda.Remove(ponuda);

            return Task.CompletedTask;
        }

        public async Task KreirajPonudu(Ponuda ponuda)
        {
            await _context.Ponuda.AddAsync(ponuda);
        }

        public Task<Ponuda> VratiPonudu(Guid id)
        {
            return _context.Ponuda
                .Include(p => p.TekuciRacuniPonudjaca)
                    .ThenInclude(t => t.Banka)
                    .Include(p => p.StavkeStruktureCene)
                    .ThenInclude(s => s.Proizvod)
                .Include(p => p.Ponudjac)
                .Include(p => p.JavniPoziv)
                .Include(p => p.InformacijeOIsporuci)
                .FirstAsync(p => p.Id == id);
        }
    }
}
