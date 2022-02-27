using Core.Abrstractions;
using Core.Domain.BankaAggregate;
using Core.Domain.BankaAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BankaRepository : IBankaRepository
    {
        private readonly PonudaDbContext _context;

        public BankaRepository(PonudaDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<Banka> VratiBanku(Guid id)
        {
            return _context.Banka.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
