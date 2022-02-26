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
             _context.Entry(ponuda).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task IzbrisiPonudu(Ponuda ponuda)
        {
            _context.Ponude.Remove(ponuda);

            return Task.CompletedTask;
        }

        public async Task KreirajPonudu(Ponuda ponuda)
        {
            await _context.Ponude.AddAsync(ponuda);
        }

        public Task<Ponuda?> VratiPonudu(Guid id)
        {
            return _context.Ponude.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
