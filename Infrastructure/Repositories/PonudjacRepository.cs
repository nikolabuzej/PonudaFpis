using Core.Abrstractions;
using Core.Domain.PonudjacAggregate;
using Core.Domain.PonudjacAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PonudjacRepository : IPonudjacRepository
    {
        private readonly PonudaDbContext _context;

        public PonudjacRepository(PonudaDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<Ponudjac> VratiPonudjaca(Guid id)
        {
            return _context.Ponudjaci.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
