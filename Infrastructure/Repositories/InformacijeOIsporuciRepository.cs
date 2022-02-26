using Core.Abrstractions;
using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.InformacijeOIsporuciAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InformacijeOIsporuciRepository : IInformacijeOIsporuciRepository
    {
        private readonly PonudaDbContext _context;

        public InformacijeOIsporuciRepository(PonudaDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<InformacijeOIsporuci> VratiInformacijeOIsporuci(Guid id)
        {
            return _context.InformacijeOIsporukama.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
