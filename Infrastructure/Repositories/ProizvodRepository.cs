using Core.Abrstractions;
using Core.Domain.ProizvodAggregate;
using Core.Domain.ProizvodAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProizvodRepository : IProizvodRepository
    {
        private readonly PonudaDbContext _context;

        public ProizvodRepository(PonudaDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<Proizvod> VratiProizvod(Guid id)
        {
            return _context.Proizvod.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
